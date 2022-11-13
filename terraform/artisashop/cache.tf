locals {
  redis_exporter_port = 9121
}

output "redis_exporter_target" {
  value = "${kubernetes_service_v1.cache.metadata[0].name}:${local.redis_exporter_port}"
}

resource "kubernetes_deployment_v1" "cache" {
  metadata {
    name      = "cache"
    namespace = var.namespace
  }
  spec {
    selector {
      match_labels = {
        app = "cache"
      }
    }
    template {
      metadata {
        namespace = var.namespace
        labels = {
          app = "cache"
        }
      }
      spec {
        # Redis container
        container {
          image = "redis:6.2.5-alpine"
          name  = "cache"
          args = [
            "--maxmemory 100mb",
            "--maxmemory-policy noeviction"
          ]
          resources {
            limits = {
              memory = "128Mi"
              cpu    = "200m"
            }
          }
          port {
            name           = "redis"
            container_port = local.cache_port
          }
        }
        # Redis exporter container, for Prometheus
        container {
          image = "oliver006/redis_exporter:v1.33.0"
          name  = "redis-exporter"
          resources {
            limits = {
              memory = "100Mi"
              cpu    = "100m"
            }
          }
          port {
            name           = "redis-exporter"
            container_port = local.redis_exporter_port
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

resource "kubernetes_service_v1" "cache" {
  metadata {
    name      = "cache"
    namespace = var.namespace
  }
  spec {
    selector = {
      app = "cache"
    }
    port {
      name = "redis"
      port = local.cache_port
    }
    port {
      name = "redis-exporter"
      port = local.redis_exporter_port
    }
    type = "ClusterIP"
  }
}
