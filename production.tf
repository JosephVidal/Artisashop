provider "kubernetes" {
  config_path = "~/.kube/config"
}

provider "helm" {
  kubernetes {
    config_path = "~/.kube/config"
  }
}

provider "kubectl" {
  config_path = "~/.kube/config"
}

# To make sure the required namespace exists on the cluster
data "kubernetes_namespace" "artisashop" {
  metadata {
    name = "artisashop"
  }
}

data "github_actions_public_key" "example_public_key" {
  repository = "Artisashop/Artisashop"
}

# resource "github_actions_secret" "example_secret" {
#   repository       = "Artisashop/Artisashop"
#   secret_name      = "example_secret_name"
#   plaintext_value  = var.some_secret_string
# }

# resource "github_actions_secret" "example_secret" {
#   repository       = "Artisashop/Artisashop"
#   secret_name      = "example_secret_name"
#   encrypted_value  = var.some_encrypted_secret_string
# }

terraform {
  required_providers {
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = "2.3.2"
    }
    helm = {
      source  = "hashicorp/helm"
      version = "2.1.2"
    }
  }
}

module "artisashop" {
  source = "./terraform/artisashop"

  namespace = "artisashop"
  host      = "artisashop.com"

  github_actions_public_key = data.github_actions_public_key.example_public_key.key
}
