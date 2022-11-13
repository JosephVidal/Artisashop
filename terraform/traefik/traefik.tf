terraform {
  required_providers {
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = ">= 2.0.0"
    }
    kubectl = {
      source  = "gavinbunney/kubectl"
      version = ">= 1.7.0"
    }
  }
}

variable "namespace" {
  type        = string
  description = "Namespace of the resources"
}

variable "hostname" {
  type        = string
  description = "Domain name where the cluster can be reached"
}

variable "traefik_web_port" {
  type        = number
  default     = 30011
  description = "Port to expose the ingresses on"
}

variable "traefik_auth_user" {
  type        = string
  sensitive   = true
  description = "Username to access the dashboard"
}

variable "traefik_auth_password" {
  type        = string
  sensitive   = true
  description = "Password to access the dashboard"
}

locals {
  traefik_api_port     = 8080
  basicauth-middleware = "traefik-basicauth"
}

# Custom resource definition for traefik middlewares
# Using the kubectl provider as the kubernetes provider cannot create a CRD and CR in the same plan
# See https://github.com/hashicorp/terraform-provider-kubernetes/issues/1367
data "kubectl_file_documents" "traefik-crds" {
  content = file("${path.module}/traefik-crd.yml")
}

resource "kubectl_manifest" "traefik-crd" {
  for_each  = data.kubectl_file_documents.traefik-crds.manifests
  yaml_body = each.value
}

# Role to give permissions to traefik for traffic routing
resource "kubernetes_cluster_role_v1" "traefik-ingress" {
  metadata {
    name = "traefik-ingress"
  }
  rule {
    api_groups = [""]
    resources  = ["services", "endpoints", "secrets"]
    verbs      = ["get", "watch", "list"]
  }
  rule {
    api_groups = ["extensions", "networking.k8s.io"]
    resources  = ["ingresses", "ingressclasses"]
    verbs      = ["get", "watch", "list"]
  }
  rule {
    api_groups = ["extensions"]
    resources  = ["ingresses/status"]
    verbs      = ["update"]
  }
  rule {
    api_groups = ["traefik.containo.us"]
    resources = [
      "middlewares",
      "middlewaretcps",
      "ingressroutes",
      "traefikservices",
      "ingressroutetcps",
      "ingressrouteudps",
      "tlsoptions",
      "tlsstores",
      "serverstransports"
    ]
    verbs = ["get", "watch", "list"]
  }
}

resource "kubernetes_cluster_role_binding_v1" "traefik-ingress" {
  metadata {
    name = "traefik-ingress"
  }
  subject {
    kind      = "ServiceAccount"
    name      = "traefik-ingress"
    namespace = var.namespace
  }
  role_ref {
    kind      = "ClusterRole"
    name      = kubernetes_cluster_role_v1.traefik-ingress.metadata[0].name
    api_group = "rbac.authorization.k8s.io"
  }
}

resource "kubernetes_service_account_v1" "traefik-ingress" {
  metadata {
    name      = "traefik-ingress"
    namespace = var.namespace
  }
}

# Ingress class to expose using traefik
resource "kubernetes_ingress_class_v1" "traefik-lb" {
  metadata {
    name = "traefik-lb"
  }
  spec {
    controller = "traefik.io/ingress-controller"
  }
}

# Output ingress class name to be used by other modules that require exposing
output "traefik_ingress_class" {
  value       = kubernetes_ingress_class_v1.traefik-lb.metadata[0].name
  description = "Ingress class consumed by traefik"
}

resource "kubernetes_deployment_v1" "traefik" {
  metadata {
    name      = "traefik-ingress"
    namespace = var.namespace
  }
  spec {
    selector {
      match_labels = {
        app = "traefik-ingress"
      }
    }
    template {
      metadata {
        namespace = var.namespace
        labels = {
          app = "traefik-ingress"
        }
      }
      spec {
        service_account_name             = kubernetes_service_account_v1.traefik-ingress.metadata[0].name
        termination_grace_period_seconds = 60
        container {
          image = "traefik:v2.5.5"
          name  = "traefik-ingress"
          resources {
            limits = {
              memory = "256Mi"
              cpu    = "350m"
            }
          }
          port {
            name           = "http"
            container_port = 80
          }
          port {
            name           = "dashboard"
            container_port = local.traefik_api_port
          }
          args = [
            "--api=true",
            "--api.dashboard=true",
            "--api.insecure=true",
            "--providers.kubernetesCRD.namespaces=${var.namespace}",
            "--providers.kubernetesCRD.ingressClass=${kubernetes_ingress_class_v1.traefik-lb.metadata[0].name}",
            "--providers.kubernetesIngress.namespaces=${var.namespace}",
            "--providers.kubernetesIngress.ingressClass=${kubernetes_ingress_class_v1.traefik-lb.metadata[0].name}",
            "--metrics.prometheus=true",
            "--log.level=ERROR"
          ]
        }
      }
    }
  }
}

output "web_port" {
  value = var.traefik_web_port
}

output "traefik_target" {
  value = "${kubernetes_service_v1.traefik.metadata[0].name}:${local.traefik_api_port}"
}

# Service to expose traefik as NodePort
resource "kubernetes_service_v1" "traefik_nodeport" {
  metadata {
    name      = "traefik-nodeport"
    namespace = var.namespace
  }
  spec {
    selector = {
      app = "traefik-ingress"
    }
    port {
      name      = "web"
      protocol  = "TCP"
      port      = 80
      node_port = var.traefik_web_port
    }
    type = "NodePort"
  }
}

# Service for pod communication
resource "kubernetes_service_v1" "traefik" {
  metadata {
    name      = "traefik"
    namespace = var.namespace
  }
  spec {
    selector = {
      app = "traefik-ingress"
    }
    port {
      name     = "web"
      protocol = "TCP"
      port     = 80
    }
    port {
      name     = "dashboard"
      protocol = "TCP"
      port     = local.traefik_api_port
    }
    type = "ClusterIP"
  }
}

resource "kubernetes_secret_v1" "traefik-auth" {
  metadata {
    name      = "traefik-auth"
    namespace = var.namespace
  }
  data = {
    users = "${var.traefik_auth_user}:${bcrypt(var.traefik_auth_password, 8)}"
  }
}

# Using the kubectl provider as the kubernetes provider cannot create a CRD and CR in the same plan
# See https://github.com/hashicorp/terraform-provider-kubernetes/issues/1367
resource "kubectl_manifest" "traefik-basicauth-middleware" {
  yaml_body = templatefile("${path.module}/dashboard-basicauth.yml", {
    name       = local.basicauth-middleware
    namespace  = var.namespace
    secretName = kubernetes_secret_v1.traefik-auth.metadata[0].name
  })
}

# Ingress to expose the traefik dashboard
resource "kubernetes_ingress_v1" "traefik-dashboard" {
  metadata {
    name      = "traefik-dashboard"
    namespace = var.namespace
    annotations = {
      "traefik.ingress.kubernetes.io/router.middlewares" = "${var.namespace}-${local.basicauth-middleware}@kubernetescrd"
    }
  }
  spec {
    ingress_class_name = kubernetes_ingress_class_v1.traefik-lb.metadata[0].name
    rule {
      host = "traefik.${var.hostname}"
      http {
        path {
          path      = "/"
          path_type = "Prefix"
          backend {
            service {
              name = kubernetes_service_v1.traefik.metadata[0].name
              port {
                number = local.traefik_api_port
              }
            }
          }
        }
      }
    }
  }
}
