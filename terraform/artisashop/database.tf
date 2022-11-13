locals {
  metrics_port = 9216
}

output "mongodb_exporter_target" {
  value = "${kubernetes_service_v1.db.metadata[0].name}:${local.metrics_port}"
}

resource "kubernetes_persistent_volume_claim_v1" "db-data-claim" {
  metadata {
    name      = "db-data-claim"
    namespace = var.namespace
  }
  wait_until_bound = false
  spec {
    access_modes       = ["ReadWriteOnce"]
    storage_class_name = data.kubernetes_storage_class_v1.local.metadata[0].name
    resources {
      requests = {
        storage = "3Gi"
      }
    }
  }
}

resource "kubernetes_deployment_v1" "db" {
  metadata {
    name      = "db"
    namespace = var.namespace
  }
  spec {
    selector {
      match_labels = {
        app = "db"
      }
    }
    strategy {
      type = "Recreate"
    }
    template {
      metadata {
        namespace = var.namespace
        labels = {
          app = "db"
        }
      }
      spec {
        # Affinity required for Mongo >=5 and for the exporter
        affinity {
          node_affinity {
            required_during_scheduling_ignored_during_execution {
              node_selector_term {
                match_expressions {
                  key      = "kubernetes.io/arch"
                  operator = "In"
                  values   = ["amd64"]
                }
              }
            }
          }
        }
        termination_grace_period_seconds = 60
        container {
          image = "mongo:5.0.5"
          name  = "db"
          resources {
            limits = {
              memory = "512Mi"
              cpu    = "500m"
            }
          }
          env {
            name = "MONGO_INITDB_ROOT_USERNAME"
            value_from {
              secret_key_ref {
                name = kubernetes_secret_v1.db_secret.metadata[0].name
                key  = "DB_USERNAME"
              }
            }
          }
          env {
            name = "MONGO_INITDB_ROOT_PASSWORD"
            value_from {
              secret_key_ref {
                name = kubernetes_secret_v1.db_secret.metadata[0].name
                key  = "DB_PASSWORD"
              }
            }
          }
          port {
            name           = "mongodb"
            container_port = local.db_port
          }
          volume_mount {
            name       = "data"
            mount_path = "/data/db"
          }
        }
        # Mongo exporter container, for Prometheus
        container {
          image = "bastiengarcia/mongodb_exporter:0.5.2"
          name  = "mongodb-exporter"
          args = [
            "--compatible-mode"
          ]
          resources {
            limits = {
              memory = "128Mi"
              cpu    = "250m"
            }
          }
          env_from {
            secret_ref {
              name = kubernetes_secret_v1.db_secret.metadata[0].name
            }
          }
          env {
            name  = "DB_PORT"
            value = local.db_port
          }
          port {
            name           = "web-interface"
            container_port = local.metrics_port
          }
        }
        volume {
          name = "data"
          persistent_volume_claim {
            claim_name = kubernetes_persistent_volume_claim_v1.db-data-claim.metadata[0].name
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

resource "kubernetes_service_v1" "db" {
  metadata {
    name      = "db"
    namespace = var.namespace
  }
  spec {
    selector = {
      app = "db"
    }
    port {
      name = "mongo"
      port = local.db_port
    }
    port {
      name = "metrics"
      port = local.metrics_port
    }
    type = "ClusterIP"
  }
}
