#! /bin/bash

#delete old containers
#docker rm -f $(docker ps -a -q)

#build and upload database
docker build -t vuci359/fer3_opencomputing_lab_exam:database_v1 ./container1-database/
docker push vuci359/fer3_opencomputing_lab_exam:database_v1

#build and upload backend
docker build -t vuci359/fer3_opencomputing_lab_exam:backend_v1 ./container3-backend/App/
docker push vuci359/fer3_opencomputing_lab_exam:backend_v1

#build and upload frontend
docker build -t vuci359/fer3_opencomputing_lab_exam:frontend_v1 ./container2-frontend/
docker push vuci359/fer3_opencomputing_lab_exam:frontend_v1