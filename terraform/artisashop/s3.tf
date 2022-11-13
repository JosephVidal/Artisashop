locals {
    minio_exporter_port = 42024
}

variable "s3_username" {
  type        = string
  sensitive   = true
  description = "Username used to modify the s3 bucket"
}

variable "s3_password" {
  type        = string
  sensitive   = true
  description = "Password used to modify the s3 bucket"
}

resource "kubernetes_persistent_volume_claim_v1" "s3-data-claim-1" {
  metadata {
    name      = "s3-data-claim-1"
    namespace = var.namespace
  }
  wait_until_bound = false
  spec {
    access_modes       = ["ReadWriteOnce"]
    storage_class_name = data.kubernetes_storage_class_v1.local.metadata[0].name
    resources {
      requests = {
        storage = "1Gi"
      }
    }
  }
}

resource "kubernetes_persistent_volume_claim_v1" "s3-data-claim-2" {
  metadata {
    name      = "s3-data-claim-2"
    namespace = var.namespace
  }
  wait_until_bound = false
  spec {
    access_modes       = ["ReadWriteOnce"]
    storage_class_name = data.kubernetes_storage_class_v1.local.metadata[0].name
    resources {
      requests = {
        storage = "1Gi"
      }
    }
  }
}

resource "kubernetes_persistent_volume_claim_v1" "s3-data-claim-3" {
  metadata {
    name      = "s3-data-claim-3"
    namespace = var.namespace
  }
  wait_until_bound = false
  spec {
    access_modes       = ["ReadWriteOnce"]
    storage_class_name = data.kubernetes_storage_class_v1.local.metadata[0].name
    resources {
      requests = {
        storage = "1Gi"
      }
    }
  }
}

resource "kubernetes_persistent_volume_claim_v1" "s3-data-claim-4" {
  metadata {
    name      = "s3-data-claim-4"
    namespace = var.namespace
  }
  wait_until_bound = false
  spec {
    access_modes       = ["ReadWriteOnce"]
    storage_class_name = data.kubernetes_storage_class_v1.local.metadata[0].name
    resources {
      requests = {
        storage = "1Gi"
      }
    }
  }
}

resource "kubernetes_deployment_v1" "s3" {
  metadata {
    name      = "s3"
    namespace = var.namespace
  }
  spec {
    selector {
      match_labels = {
        app = "s3"
      }
    }
    template {
      metadata {
        namespace = var.namespace
        labels = {
          app = "s3"
        }
      }
      spec {
        container {
          image = "minio/minio:latest"
          name  = "s3"
          args  = ["server", "/data{1...4}"]
          resources {
            limits = {
              memory = "256Mi"
              cpu    = "500m"
            }
          }
          port {
            name           = "minio"
            container_port = local.s3_port
          }
          liveness_probe {
            http_get {
              path = "http://localhost/minio/health/live"
              port = local.s3_port
            }
            initial_delay_seconds = 10
            period_seconds        = 20
            timeout_seconds       = 5
          }
          env {
            name  = "MINIO_ROOT_USER"
            value = var.s3_username
          }
          env {
            name  = "MINIO_ROOT_PASSWORD"
            value = var.s3_password
          }
          env {
            name  = "MINIO_PROMETHEUS_AUTH_TYPE"
            value = "public"
          }
          volume_mount {
            name       = "data1"
            mount_path = "/data1"
          }
          volume_mount {
            name       = "data2"
            mount_path = "/data2"
          }
          volume_mount {
            name       = "data3"
            mount_path = "/data3"
          }
          volume_mount {
            name       = "data4"
            mount_path = "/data4"
          }
        }
        volume {
          name = "data1"
          persistent_volume_claim {
            claim_name = kubernetes_persistent_volume_claim_v1.s3-data-claim-1.metadata[0].name
          }
        }
        volume {
          name = "data2"
          persistent_volume_claim {
            claim_name = kubernetes_persistent_volume_claim_v1.s3-data-claim-2.metadata[0].name
          }
        }
        volume {
          name = "data3"
          persistent_volume_claim {
            claim_name = kubernetes_persistent_volume_claim_v1.s3-data-claim-3.metadata[0].name
          }
        }
        volume {
          name = "data4"
          persistent_volume_claim {
            claim_name = kubernetes_persistent_volume_claim_v1.s3-data-claim-4.metadata[0].name
          }
        }
      }
    }
  }
  timeouts {
    create = "3m"
    update = "2m"
    delete = "3m"
  }
}

resource "kubernetes_service_v1" "s3" {
  metadata {
    name      = "s3"
    namespace = var.namespace
  }
  spec {
    selector = {
      app = "s3"
    }
    port {
      port = local.s3_port
    }
    type = "ClusterIP"
  }
}

locals {
  s3_host  = "s3.${var.host}"
}

output "s3_host" {
  value       = local.s3_host
  description = "Domain name of the s3 service"
}

output "minio_exporter_target" {
  value = "${kubernetes_service_v1.s3.metadata[0].name}:9000"
}

resource "kubernetes_ingress_v1" "s3" {
  metadata {
    name      = "s3"
    namespace = var.namespace
  }
  spec {
    ingress_class_name = var.ingress_class
    rule {
      host = local.s3_host
      http {
        path {
          path      = "/"
          path_type = "Prefix"
          backend {
            service {
              name = kubernetes_service_v1.s3.metadata[0].name
              port {
                number = local.s3_port
              }
            }
          }
        }
      }
    }
  }
}
