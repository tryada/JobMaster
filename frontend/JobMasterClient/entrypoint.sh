#!/bin/sh

if [ -z "$API_URL" ]; then
  echo "API_URL environment variable is not set. Using default value."
  export API_URL="https://localhost:6060"
else
  echo "Using API_URL from environment variable: $API_URL"
fi

envsubst < ./src/environments/environment.docker.ts > ./src/environments/environment.docker.tmp.ts && \
mv ./src/environments/environment.docker.tmp.ts ./src/environments/environment.docker.ts

exec "$@"