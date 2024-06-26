#!/bin/bash

MODE=$1

if [ "$MODE" = "ci" ]; then
    docker compose -f .docker/db-ci.yml up -d
else
    docker compose -f .docker/db.yml up -d
fi

docker compose \
    -f .docker/historie-data-service.yml \
    -f .docker/historie-informatie-service.yml \
    up -d
