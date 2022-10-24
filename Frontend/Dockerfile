FROM node:16 as build

WORKDIR /app

COPY ./ ./

RUN yarn install
RUN yarn build

FROM nginx:latest

COPY ./nginx/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist /usr/share/nginx/html
