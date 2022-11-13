terraform {
  required_providers {
    helm = {
      source  = "hashicorp/helm"
      version = "2.4.1"
    }
  }
}

variable "namespace" {
  type        = string
  description = "Namespace of the resources"
}

resource "helm_release" "secret_generator" {
  name       = "secret-generator"
  repository = "https://helm.mittwald.de"
  chart      = "kubernetes-secret-generator"
  version    = "3.3.4"
  namespace  = var.namespace

  set {
    name  = "watchNamespace"
    value = var.namespace
  }
  set {
    name  = "nodeSelector.kubernetes\\.io/arch"
    value = "amd64"
  }
}
