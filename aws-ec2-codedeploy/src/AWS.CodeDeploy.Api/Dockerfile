FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AWS.CodeDeploy.Api.csproj", "src/AWS.CodeDeploy.Api/"]
RUN dotnet restore "src/AWS.CodeDeploy.Api/AWS.CodeDeploy.Api.csproj"
COPY . .
WORKDIR "/src/AWS.CodeDeploy.Api"
RUN dotnet build "/src/AWS.CodeDeploy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/AWS.CodeDeploy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AWS.CodeDeploy.Api.dll"]