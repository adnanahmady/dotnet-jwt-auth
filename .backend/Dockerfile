FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine

RUN apk add --no-cache sudo vim wget nano bash

RUN adduser -D -h /home/docker -s /bin/bash docker \
    && echo "docker ALL=(ALL) NOPASSWD:ALL" >> /etc/sudoers
