#!/bin/sh


echo "部署"
docker rm -f shellpublish
docker rmi shellpublish

docker build -t shellpublish .

echo "运行"

docker run -d -p 3333:80 --name shellpublish shellpublish