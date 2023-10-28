@echo off
echo Building Docker image...
docker build -t brilliance.mysql .

echo Starting Docker container...
docker run --name brilliance-container -p 3307:3306 -d brilliance.mysql

echo Container is up and running.
