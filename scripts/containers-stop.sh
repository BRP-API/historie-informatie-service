#!/bin/bash

MODE=$1

if [ "$MODE" = "ci" ]; then
    docker compose -f .docker/db-ci.yml down
else
    docker compose -f .docker/db.yml down
fi

docker compose \
    -f .docker/historie-data-service.yml \
    -f .docker/historie-informatie-service.yml \
    down
