#!/bin/bash
cp docker/.env.dist docker/.env 

docker-compose --env-file docker/.env build && docker-compose --env-file docker/.env up