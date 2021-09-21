#!/usr/bin/env bash
# az login -u <username> -p <password>

run() {
  az ad sp create-for-rbac --name "FunctionCalculator" --role contributor \
    --scopes /subscriptions/$1/resourceGroups/$2 \
    --sdk-auth
}
run $(cat ./secrets/sub-id.secret) $(cat ./secrets/res-group.secret)

# az ad sp create-for-rbac --name "myApp" --role contributor \
#   --scopes /subscriptions/{subscription-id}/resourceGroups/{resource-group} \
#   --sdk-auth

# Replace {subscription-id}, {resource-group} with the subscription, resource group details

# The command should output a JSON object similar to this:

# {
#   "clientId": "<GUID>",
#   "clientSecret": "<GUID>",
#   "subscriptionId": "<GUID>",
#   "tenantId": "<GUID>",
#   (...)
# }
