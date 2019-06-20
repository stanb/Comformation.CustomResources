FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["RunTerraform.App/RunTerraform.App.csproj", "RunTerraform.App/"]
RUN dotnet restore "RunTerraform.App/RunTerraform.App.csproj"
COPY . .
WORKDIR "/src/RunTerraform.App"
RUN dotnet build "RunTerraform.App.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RunTerraform.App.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RunTerraform.App.dll"]
