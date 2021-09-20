#!/usr/bin/env bash
echo --------Running HTTP-tests with curl-------------
score=$(bash curltests.sh $(cat -s ./.secretss 2>/dev/null))
if [[ $? -ne 0 ]]; then
    echo --------Testing failed-----------------------
    exit 1
else
    echo Test Score: $score
    echo --------End of test-------------
fi

# Since you are using a HTTP Trigger make sure your url is in the following format
# https://<APP_NAME>.azurewebsites.net/api/<FUNCTION_NAME>?code=<API_KEY>
# http://<APP_NAME>.azurewebsites.net/api/<FUNCTION_NAME>

# Add the following headers:

# x-functions-key: A function-specific API key is required. Default if specific is not provided
# Content-Type: application/json
