FROM node:18 as build
RUN ["corepack", "enable"]
RUN ["yarn", "set", "version", "stable"]
WORKDIR /usr/src/app
COPY package.json yarn.lock .yarn .yarnrc.yml ./
RUN yarn install
COPY . ./
RUN yarn build

FROM nginx:1.15 as prod
COPY --from=build /usr/src/app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
