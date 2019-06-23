#FROM microsoft/dotnet:2.1-runtime AS base
FROM mcr.microsoft.com/dotnet/core/runtime-deps:2.1-alpine3.9
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY RunTerraform.App/RunTerraform.App.csproj RunTerraform.App/
RUN dotnet restore RunTerraform.App/RunTerraform.App.csproj
COPY . .
WORKDIR /src/RunTerraform.App
RUN dotnet build RunTerraform.App.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RunTerraform.App.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN ["chmod", "+x", "install.sh"]
ENTRYPOINT ["dotnet", "RunTerraform.App"]
