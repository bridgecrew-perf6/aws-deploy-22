FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AWS.EBDeploy.Api.csproj", "src/AWS.EBDeploy.Api/"]
RUN dotnet restore "src/AWS.EBDeploy.Api/AWS.EBDeploy.Api.csproj"
COPY . .
WORKDIR "/src/AWS.EBDeploy.Api"
RUN dotnet build "/src/AWS.EBDeploy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/AWS.EBDeploy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AWS.EBDeploy.Api.dll"]