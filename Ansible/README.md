# Artisashop ansible playbooks

## Introduction

The purpose of this document is to brief you on how to use ansible playbooks in order to deploy artisashop project

## Description

### Roles

Running any of these roles requires the steps executed by **requirements** role to be executed at 
least one time on the distant machine before using any other roles.

#### artisashop

Deploy all containers but traefik.

**extra requirements**

- artisashop repo deploy key (see [here](https://docs.gitlab.com/ee/user/project/deploy_keys/))

#### deploy

Template task that clone repository, copy the docker-compose in host target folder and lauch it

#### new_user

Create new user, give him access through current ssh key.

N.B. : This role can only be used with a sudoer. Use -k option to provide password, or disable password prompt on the host.

#### requirements

Install all the requirements of artisashop project.

**extra requirements :**

- A user "admin" has been created
- "admin" user is sudo
- "admin" user do not ask for password (uses -k option if it is not possible)
- Distant machine accept ssh connection on "admin" from the machine executing the playbook

#### secret

Ensure that a .secret folder exists at the root of the targeted user and copy env file and deploy key (if defined).

#### traefik

Deploy traefik container under the targeted host, using provided env-file.

**extra requirements :**

- .env file containing the definition of at least the following variables :
  - ARTISASHOP_HOST
  - TRAEFIK_DOCKER_NETWORK
  - configuration for dns challenge (see [here](https://doc.traefik.io/traefik/user-guides/docker-compose/acme-dns/))

### Playbooks

#### playbook-prod.yml

Deploy project under different users as follows :

- admin : install dependencies and creates user "artisashop" and "traefik"

- traefik : deploy traefik

- artisashop : deploy artisashop project

Run it using the following command :

```bash
ansible-playbook playbook-prod.yml -i <your inventory>
```

> N.B. : A default inventory is provided through `inventory.yml` file  

> N.B. : You can add "-t <role>" flag to limit the execution to an explicit set of roles 

##### The command you will most likely use

```bash
ansible-playbook playbook-prod.yml -i inventory.yml -t artisashop -l main
```  
  
Launches the role with the tag `artisashop` from `playbook-prod.yml` to the computer named `main`

#### playbook-dev.yml

This playbook is the same as `playbook-prod.yml` execept that the exposition address has been
changed.

Launch this playbook using the following command :

```bash
ansible-playbook playbook-dev.yml -i <inventory>
```

N.B. : A default inventory is provided through `inventory.yml` file

##### The command you will most likely use

```bash
ansible-playbook playbook-dev.yml -i inventory.yml -t artisashop-dev -l main
```  
  
Launches the role with the tag `artisashop-dev` from `playbook-dev.yml` to the computer named `main`

### Environment variables

There is no environment variable to set up in order setup parameters, other than the ones provided by ansible itself