#!/usr/bin/env bash
echo get
curl http://localhost:7071/api/HttpTrigger?query1=test
echo
### Simple get
echo post
# curl -X POST -d 'name=robin&alias=bob' http://localhost:7071/api/HttpTrigger
curl -X POST -d 'name=robin' -d 'alias=bobby' http://localhost:7071/api/HttpTrigger?try=ett
### post request
echo
