terraform {
  required_providers {
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = "2.3.2"
    }
  }
}

variable "namespace" {
  type        = string
  description = "Namespace of the resource"
}

variable "host" {
  type        = string
  description = "Domain name where the pods are accessible"
  default     = "localhost"
}

locals {
  api_port   = 8080
  s3_port    = 9000
  cache_port = 6379
  db_port    = 27017
}

resource "kubernetes_service" "artisashop" {
  metadata {
    name      = "artisashop"
    namespace = var.namespace
  }

  spec {
    selector = {
      app = "artisashop"
    }

    port {
      name = "http"
      port = local.api_port
    }

    type = "LoadBalancer"
  }
}