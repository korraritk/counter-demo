FROM node:20 AS build
WORKDIR /src
COPY . .
RUN npm ci
RUN npm run build

FROM nginx:alpine
COPY --from=build /src/dist/frontend/browser /usr/share/nginx/html
EXPOSE 80