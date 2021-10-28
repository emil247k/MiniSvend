FROM node:latest as build
COPY ./Solution/Application/Frontend/SmartLock/ /data/
WORKDIR /data/
RUN npm run build

FROM nginx as server
COPY --from=build /data/dist/SmartLock /usr/share/nginx/html
EXPOSE 80