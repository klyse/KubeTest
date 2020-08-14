FROM golang:1.15.0-alpine AS build
WORKDIR /src
COPY . .
ENV GOOS linux
ENV GOARCH amd64
RUN go build -o /out/randomService .

FROM golang:1.15.0-alpine AS bin
COPY --from=build /out/randomService /
ENTRYPOINT ["/randomService"]
