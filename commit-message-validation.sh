#!/bin/bash

# This hook checks the commit starts with prefix "[AT-*]:".

red='\033[0;31m'
default='\033[0m'
error_msg="Commit annulé.

Le message $(cat $1) doit respecter le pattern suivant :
    [Stack de la tâche][Domaine de la tâche] Votre message

Par exemple :
    [Frontend][Structure]: Push front structure"

if [[ ! $(cat $1) =~ ^(\[(Frontend|Backend|Fullstack|Devops)\]\[(Auth|Catalog|Chat|Order|Contact|Documents|Payment|Basket|Home|Admin|Test|Devops|Structure)\])* ]]; then
    echo "$error_msg" >&2
	exit 1
fi
