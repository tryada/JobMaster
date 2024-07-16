FROM node:alpine

RUN npm install -g @angular/cli
RUN apk add gettext

WORKDIR /usr/local/app

COPY frontend/JobMasterClient/package*.json .
RUN npm install

COPY frontend/JobMasterClient .
RUN ng build --configuration docker

RUN chmod +x entrypoint.sh

ENTRYPOINT ["/usr/local/app/entrypoint.sh"]

CMD ["ng", "serve", "--configuration", "docker", "--host", "0.0.0.0"]