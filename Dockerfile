FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN apt update && apt install -y curl unzip
RUN curl -OL https://github.com/protocolbuffers/protobuf/releases/download/v3.6.1/protoc-3.6.1-linux-x86_64.zip && \
  unzip protoc-3.6.1-linux-x86_64.zip -d protoc3 && \
  mv protoc3/bin/* /usr/local/bin/ && \
  mv protoc3/include/* /usr/local/include/ && \
  chmod 755 -R /usr/local/include

WORKDIR /build

COPY src/PoohSticks.Common ./src/PoohSticks.Common
COPY src/PoohSticks.Web ./src/PoohSticks.Web

RUN dotnet restore ./src/PoohSticks.Common/PoohSticks.Common.csproj
RUN dotnet restore ./src/PoohSticks.Web/PoohSticks.Web.csproj
