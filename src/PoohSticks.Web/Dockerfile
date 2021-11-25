FROM poohsticks:latest AS build

COPY protos/ ./protos/

COPY src/PoohSticks.Common ./src/PoohSticks.Common
COPY src/PoohSticks.Messages ./src/PoohSticks.Messages
COPY src/PoohSticks.Web ./src/PoohSticks.Web

RUN dotnet publish --no-restore -c Release -o out ./src/PoohSticks.Web/PoohSticks.Web.csproj

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=build /build/out .
ENTRYPOINT ["dotnet", "PoohSticks.Service.dll"]
