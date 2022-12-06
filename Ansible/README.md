# Artisashop Ansible Playbooks

Ansible is used to automate the setup of the server, and the deployment of the project, along with monitoring and other services.

What the ansible scripts basically do is they setup the machine with users and roles, then clone the project and launch it with docker-compose.
It also setup monitoring and a backup routine with [Systemd Timers].

[Ansible inventory] is used to define the hosts and their parameters.

## Pre-requisites

### Ansible collections

To use Ansible with docker, we need to use [Ansible Galaxy] to install the [Ansible-Community docker collection].  

You can install `community.docker` it with the following command :

```bash
ansible-galaxy collection install community.docker
```

### Secrets

The secrets are stored in a super secure place, and will only be given to you if you ask nicely.

Once you have the mega-secret zip, check if you have everything :

- `.env-artisashop` : The environment variables for the artisashop role
- `deployment_key` : The deployment key for the artisashop repo, either RSA or ED25519 depending on the mood
- `deployment_key.pub` : The public key for the deployment key, it's not really needed but it's still here for reference
- `.env-traefik` : The environment variables for the traefik role, it is secret because it contains the OVH API key and secret for the DNS setup

Once you have those, you can either put them in `roles/artisashop/files/` (except `.env-traefik` which goes in `roles/traefik/files/`) or you can put them in any folder and use the `--extra-vars` flag with the `ansible-playbook` command to specify the path to the secrets.  
The option should look like this if you put all the secret files in a `ansible/.secrets/` directory :

```bash
ansible-playbook [...] \
  --extra-vars 'traefik_env_file="$(pwd)/.secrets/.env-traefik" artisashop_deploy_key="$(pwd)/.secrets/deployment_key" [...]'
```

If you use the extra-vars option, refer to the `vars:` sections in the playbook file, or just run it and it will tell you what it's missing.

## Usage

To deploy the project in production (while waiting for proper CI...), use the default inventory `inventory.yml` and the `playbook-prod.yml` playbook.

```bash
ansible-playbook playbook-prod.yml -i inventory.yml # add -vvv if you want the juicy details
```

## Roles

Running any of these roles requires the steps executed by **requirements** role to be executed at 
least one time on the distant machine before using any other roles.

### artisashop

Deploy all containers but traefik.

**extra requirements**

- Artisashop repo deploy key (see [here](https://docs.github.com/en/developers/overview/managing-deploy-keys))
- Must be done after the `traefik` role has been executed at least one time on the distant machine.

### deploy

Template task that clone repository, copy the docker-compose in host target folder and lauch it

### new_user

Create new user, give him access through current ssh key.

N.B. : This role can only be used with a sudoer. Use -k option to provide password, or disable password prompt on the host.

### requirements

Install all the requirements of artisashop project.

**extra requirements :**

- A user "admin" has been created
- "admin" user is sudo
- "admin" user do not ask for password (uses -k option if it is not possible)
- Distant machine accept ssh connection on "admin" from the machine executing the playbook

### secret

Ensure that a .secret folder exists at the root of the targeted user and copy env file and deploy key (if defined).

### traefik

Deploy traefik container under the targeted host, using provided env-file.

**extra requirements :**

- .env file containing the definition of at least the following variables :
  - ARTISASHOP_HOST
  - TRAEFIK_DOCKER_NETWORK
  - configuration for dns challenge (see [here](https://doc.traefik.io/traefik/user-guides/docker-compose/acme-dns/))

## Playbooks

### playbook-prod.yml

Deploy project under different users as follows :

- admin : install dependencies and creates user "artisashop" and "traefik"

- traefik : deploy traefik

- artisashop : deploy artisashop project

Run it using the following command :

```bash
ansible-playbook playbook-prod.yml -i <your inventory>
```

> N.B. : A default inventory is provided through `inventory.yml` file  

> N.B. : You can add `-t <role>` flag to limit the execution to an explicit set of roles 

> N.B : You can add `--extra-vars ''` to provide the path to the .env file

#### The command you will most likely use

```bash
ansible-playbook playbook-prod.yml -i inventory.yml -t artisashop -l main
```  
  
Launches the role with the tag `artisashop` from `playbook-prod.yml` to the computer named `main`

### playbook-dev.yml

This playbook is the same as `playbook-prod.yml` execept that the exposition address has been
changed.

Launch this playbook using the following command :

```bash
ansible-playbook playbook-dev.yml -i <inventory>
```

N.B. : A default inventory is provided through `inventory.yml` file

## Environment variables

There is no environment variable to set up in order setup parameters, other than the ones provided by ansible itself

<!-- Glossary -->
[Ansible]: https://docs.ansible.com/ansible/latest//index.html
[Ansible Inventory]: https://docs.ansible.com/ansible/latest//user_guide/intro_inventory.html
[Ansible Playbook]: https://docs.ansible.com/ansible/latest//user_guide/playbooks.html
[Ansible Variables]: https://docs.ansible.com/ansible/latest//user_guide/playbooks_variables.html
[Ansible Roles]: https://docs.ansible.com/ansible/latest//user_guide/playbooks_reuse_roles.html
[Ansible Vault]: https://docs.ansible.com/ansible/latest//user_guide/vault.html
[Ansible Galaxy]: https://galaxy.ansible.com/
[Ansible-Community Docker Collection]: https://github.com/ansible-collections/community.docker/blob/main/galaxy.yml

[Systemd Timers]: https://wiki.archlinux.org/title/systemd/Timers