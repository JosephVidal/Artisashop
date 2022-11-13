# Install Microk8s

To install Microk8s, please follow the instructions here
<https://microk8s.io/>

## Install the addons

Once installed, add the following add-ons:

```bash
 microk8s enable dashboard dns registry istio storage

microk8s enable cert-manager

microk8s kubectl apply -f - <<EOF
---
apiVersion: cert-manager.io/v1
kind: ClusterIssuer
metadata:
  name: letsencrypt
spec:
  acme:
    # You must replace this email address with your own.
    # Let's Encrypt will use this to contact you about expiring
    # certificates, and issues related to your account.
    email: thomascolona3@gmail.com
    server: https://acme-v02.api.letsencrypt.org/directory
    privateKeySecretRef:
      # Secret resource that will be used to store the account's private key.
      name: letsencrypt-account-key
    # Add a single challenge solver, HTTP01 using nginx
    solvers:
    - http01:
        ingress:
          class: public
EOF

microk8s enable ingress

microk8s kubectl create ingress my-ingress     --annotation cert-manager.io/cluster-issuer=letsencrypt     --rule 'my-service.example.com/*=my-service:80,tls=my-service-tls'


```

### What do they do ?

#### Dashboard

The dashboard is a web-based UI to manage your cluster. It is available at <https://artisashop.fr:10443>

#### DNS

The DNS addon provides a DNS server that can be used to resolve services running in the cluster.

#### Registry

The registry addon provides a private registry that can be used to store and distribute images.

#### Istio

Istio is a service mesh that provides a way to control the traffic between services.

#### Storage

The storage addon provides a storage class that can be used to create persistent volumes.

#### Cert-manager

The cert-manager addon provides a way to manage certificates.
