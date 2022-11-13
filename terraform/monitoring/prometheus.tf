resource "helm_release" "prometheus" {
  name          = "prometheus"
  repository    = "https://prometheus-community.github.io/helm-charts"
  chart         = "prometheus"
  version       = "15.0.2"
  namespace     = var.namespace
  reuse_values  = true
  recreate_pods = true

  values = [
    templatefile("${path.module}/prometheus-config.yml",
      {
        namespace             = var.namespace,
        hostIp                = var.hostIp,
        hostname              = local.hostname
        pathPrefix            = var.prometheus_path_prefix
        traefikTarget         = var.prometheus_traefik_target
        redisExporterTarget   = var.prometheus_redis_exporter_target
        mongodbExporterTarget = var.prometheus_mongodb_exporter_target
        minioExporterName     = local.prometheus_minio_exporter_name
        minioExporterTarget   = var.prometheus_minio_exporter_target
      }
    )
  ]
}

data "kubernetes_service_v1" "prometheus-server" {
  metadata {
    name      = "prometheus-server"
    namespace = var.namespace
  }
  depends_on = [
    helm_release.prometheus
  ]
}

locals {
  basicauth-middleware = "prometheus-basicauth"
}

resource "kubernetes_secret_v1" "prometheus-auth" {
  metadata {
    name      = "prometheus-auth"
    namespace = var.namespace
  }
  data = {
    users = "${var.prometheus_auth_user}:${bcrypt(var.prometheus_auth_password)}"
  }
}

# Using the kubectl provider as the kubernetes provider cannot create a CRD and CR in the same plan
# See https://github.com/hashicorp/terraform-provider-kubernetes/issues/1367
resource "kubectl_manifest" "prometheus-basicauth-middleware" {
  yaml_body = templatefile("${path.module}/traefik-middleware/prometheus-basicauth.yml", {
    name       = local.basicauth-middleware
    namespace  = var.namespace
    secretName = kubernetes_secret_v1.prometheus-auth.metadata[0].name
  })
}

# Create ingress to expose prometheus server
resource "kubernetes_ingress_v1" "prometheus" {
  metadata {
    name      = "prometheus"
    namespace = var.namespace
    annotations = {
      "traefik.ingress.kubernetes.io/router.middlewares" = <<EOT
        ${var.namespace}-${local.stripprefix-middleware}@kubernetescrd,
        ${var.namespace}-${local.basicauth-middleware}@kubernetescrd
        EOT
    }
  }
  spec {
    ingress_class_name = var.ingress_class
    rule {
      host = local.hostname
      http {
        path {
          path      = var.prometheus_path_prefix
          path_type = "Prefix"
          backend {
            service {
              name = data.kubernetes_service_v1.prometheus-server.metadata[0].name
              port {
                number = data.kubernetes_service_v1.prometheus-server.spec[0].port[0].port
              }
            }
          }
        }
      }
    }
  }
}
