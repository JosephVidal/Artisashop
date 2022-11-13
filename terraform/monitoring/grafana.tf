locals {
  grafana_port   = 3000
  prometheus_uid = "prometheus"
}

resource "kubernetes_config_map_v1" "grafana-datasource" {
  metadata {
    name      = "grafana-datasource"
    namespace = var.namespace
  }
  data = {
    "datasource.yaml" = templatefile("${path.module}/grafana-config/datasource.yml", {
      prometheus-server = data.kubernetes_service_v1.prometheus-server.metadata[0].name
      uid               = local.prometheus_uid
    })
  }
}

resource "kubernetes_config_map_v1" "grafana-dashboards" {
  metadata {
    name      = "grafana-dashboards"
    namespace = var.namespace
  }
  data = {
    "dashboards.yaml" = file("${path.module}/grafana-config/dashboards.yml")
    "traefik.json" = templatefile("${path.module}/grafana-config/traefik.json", {
      DS_TRAEFIK = local.prometheus_uid
    })
    "redis.json" = templatefile("${path.module}/grafana-config/redis.json", {
      DS_PROM = local.prometheus_uid
    })
    "cluster-monitor.json" = file("${path.module}/grafana-config/cluster-monitor.json")
    "prometheus-monitor.json" = templatefile("${path.module}/grafana-config/prometheus-monitor.json", {
      DS_THEMIS = local.prometheus_uid
    })
    "mongodb.json" = templatefile("${path.module}/grafana-config/mongodb.json", {
      DS_PROMETHEUS = local.prometheus_uid
    })
    "minio.json" = templatefile("${path.module}/grafana-config/minio.json", {
      DS_PROMETHEUS  = local.prometheus_uid,
      MINIO_EXPORTER = local.prometheus_minio_exporter_name
    })
  }
}

resource "kubernetes_secret_v1" "grafana_auth" {
  metadata {
    name      = "grafana-auth"
    namespace = var.namespace
  }
  data = {
    ADMIN_USER     = var.grafana_auth_user
    ADMIN_PASSWORD = var.grafana_auth_password
  }
}

resource "kubernetes_deployment_v1" "grafana" {
  metadata {
    name      = "grafana"
    namespace = var.namespace
  }
  spec {
    selector {
      match_labels = {
        app = "grafana"
      }
    }
    template {
      metadata {
        namespace = var.namespace
        labels = {
          app = "grafana"
        }
        annotations = {
          # By default, env var changes just update the values in currently running pods, which
          # does nothing as they are only used at startup
          # Use config map hash to make kubernetes restart the pods on change
          "config-hash-datasource" = base64sha256(jsonencode(kubernetes_config_map_v1.grafana-datasource.data))
          "config-hash-dashboards" = base64sha256(jsonencode(kubernetes_config_map_v1.grafana-dashboards.data))
        }
      }
      spec {
        container {
          image = "grafana/grafana:8.3.3"
          name  = "grafana"
          port {
            name           = "grafana"
            container_port = local.grafana_port
          }
          env {
            name  = "GF_SERVER_ROOT_URL"
            value = "http://${var.hostname}${var.grafana_path_prefix}"
          }
          env {
            name  = "GF_SERVER_SERVE_FROM_SUB_PATH"
            value = "true"
          }
          env {
            name  = "GF_SERVER_ENABLE_GZIP"
            value = "true"
          }
          env {
            name  = "GF_INSTALL_PLUGINS"
            value = "grafana-piechart-panel 1.6.2"
          }
          env {
            name = "GF_SECURITY_ADMIN_USER"
            value_from {
              secret_key_ref {
                name = kubernetes_secret_v1.grafana_auth.metadata[0].name
                key  = "ADMIN_USER"
              }
            }
          }
          env {
            name = "GF_SECURITY_ADMIN_PASSWORD"
            value_from {
              secret_key_ref {
                name = kubernetes_secret_v1.grafana_auth.metadata[0].name
                key  = "ADMIN_PASSWORD"
              }
            }
          }
          volume_mount {
            name       = "grafana-datasource"
            mount_path = "/etc/grafana/provisioning/datasources/datasource.yaml"
            sub_path   = "datasource.yaml"
          }
          volume_mount {
            name       = "grafana-dashboards"
            mount_path = "/etc/grafana/provisioning/dashboards"
          }
        }
        volume {
          name = "grafana-datasource"
          config_map {
            name = kubernetes_config_map_v1.grafana-datasource.metadata[0].name
          }
        }
        volume {
          name = "grafana-dashboards"
          config_map {
            name = kubernetes_config_map_v1.grafana-dashboards.metadata[0].name
          }
        }
      }
    }
  }
}

resource "kubernetes_service_v1" "grafana" {
  metadata {
    name      = "grafana"
    namespace = var.namespace
  }
  spec {
    selector = {
      app = "grafana"
    }
    port {
      name     = "grafana"
      protocol = "TCP"
      port     = local.grafana_port
    }
  }
}

resource "kubernetes_ingress_v1" "grafana" {
  metadata {
    name      = "grafana"
    namespace = var.namespace
    annotations = {
      "traefik.ingress.kubernetes.io/router.middlewares" = <<EOT
      ${var.namespace}-${local.redirect-middleware}@kubernetescrd,
      ${var.namespace}-${local.stripprefix-middleware}@kubernetescrd
      EOT
    }
  }
  spec {
    ingress_class_name = var.ingress_class
    rule {
      host = "monitoring.${var.hostname}"
      http {
        path {
          path      = var.grafana_path_prefix
          path_type = "Prefix"
          backend {
            service {
              name = kubernetes_service_v1.grafana.metadata[0].name
              port {
                number = local.grafana_port
              }
            }
          }
        }
        path {
          path      = "/"
          path_type = "Exact"
          backend {
            service {
              name = kubernetes_service_v1.grafana.metadata[0].name
              port {
                number = local.grafana_port
              }
            }
          }
        }
      }
    }
  }
}
