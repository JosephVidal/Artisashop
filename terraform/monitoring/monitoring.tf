terraform {
  required_providers {
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = ">= 2.0.0"
    }
    helm = {
      source  = "hashicorp/helm"
      version = "2.4.1"
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

variable "hostIp" {
  type        = string
  description = "Ip where the cluster can be reached"
}

variable "ingress_class" {
  type        = string
  description = "Ingress class to use"
}

variable "grafana_path_prefix" {
  type        = string
  default     = "/grafana"
  description = "Path prefix routing to grafana"
}

variable "prometheus_path_prefix" {
  type        = string
  default     = "/prometheus"
  description = "Path prefix routing to prometheus"
}

variable "prometheus_traefik_target" {
  type        = string
  description = "Hostname and port to reach the traefik api"
}

variable "prometheus_redis_exporter_target" {
  type        = string
  description = "Hostname and port to reach the redis exporter"
}

variable "prometheus_mongodb_exporter_target" {
  type        = string
  description = "Hostname and port to reach the mongodb exporter"
}

variable "prometheus_auth_user" {
  type        = string
  sensitive   = true
  description = "Username to access the dashboard"
}

variable "prometheus_auth_password" {
  type        = string
  sensitive   = true
  description = "Password to access the dashboard"
}

variable "prometheus_minio_exporter_target" {
  type        = string
  description = "Hostname and port to reach the minio exporter"
}

variable "grafana_auth_user" {
  type        = string
  sensitive   = true
  description = "Username to access the dashboard"
}

variable "grafana_auth_password" {
  type        = string
  sensitive   = true
  description = "Password to access the dashboard"
}

locals {
  stripprefix-middleware = "monitoring-stripprefix"
  redirect-middleware    = "monitoring-redirect"
  hostname               = "monitoring.${var.hostname}"
  prometheus_minio_exporter_name = "minio_exporter"
}

# Using the kubectl provider as the kubernetes provider cannot create a CRD and CR in the same plan
# See https://github.com/hashicorp/terraform-provider-kubernetes/issues/1367
resource "kubectl_manifest" "monitoring-stripprefix-middleware" {
  yaml_body = templatefile("${path.module}/traefik-middleware/monitoring-stripprefix.yml", {
    name                   = local.stripprefix-middleware
    namespace              = var.namespace
    grafana_path_prefix    = var.grafana_path_prefix
    prometheus_path_prefix = var.prometheus_path_prefix
  })
}

resource "kubectl_manifest" "monitoring-redirect-middleware" {
  yaml_body = templatefile("${path.module}/traefik-middleware/monitoring-redirect.yml", {
    name                = local.redirect-middleware
    namespace           = var.namespace
    hostname            = local.hostname
    grafana_path_prefix = var.grafana_path_prefix
  })
}
