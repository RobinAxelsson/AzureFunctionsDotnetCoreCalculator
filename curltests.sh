#!/usr/bin/env bash
curl http://localhost:7071/api/HttpTrigger?name=Robin
echo
### Simple get

# curl -X POST -d 'name=robin' http://localhost:7071/api/HttpTrigger
### simple post

# # curl -X POST -d 'name=robin&alias=bob' http://localhost:7071/api/HttpTrigger
# curl -X POST -d 'name=robin' -d 'alias=bobby' http://localhost:7071/api/HttpTrigger?try=ett
# ### post request
# echo
