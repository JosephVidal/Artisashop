variable "namespace" {
  type        = string
  description = "Namespace of the resources"
}

# Role to give permissions for devs to
# - check logs
# - port-forward
# - exec
resource "kubernetes_role_v1" "developer" {
  metadata {
    name      = "developer"
    namespace = var.namespace
  }
  rule {
    api_groups = [""]
    resources  = ["pods", "pods/logs"]
    verbs      = ["get", "watch", "list"]
  }
  rule {
    api_groups = [""]
    resources  = ["pods/portforward"]
    verbs      = ["get", "list", "create"]
  }
  rule {
    api_groups = [""]
    resources  = ["pods/exec"]
    verbs      = ["create"]
  }
}

resource "kubernetes_role_binding_v1" "developer" {
  metadata {
    name = "developer"
    namespace = var.namespace
  }
  role_ref {
    api_group = "rbac.authorization.k8s.io"
    kind = "Role"
    name = "developer"
  }
  subject {
    kind = "User"
    name = "developer"
    api_group = "rbac.authorization.k8s.io"
  }
}
