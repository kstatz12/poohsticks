#!/usr/bin/env bash
set -euo pipefail

docker build . -t poohsticks:latest
docker-compose up -d --build
