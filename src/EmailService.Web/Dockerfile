#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/EmailService.Web/EmailService.Web.csproj", "src/EmailService.Web/"]
COPY ["src/EmailService.Core/EmailService.Core.csproj", "src/EmailService.Core/"]
COPY ["src/EmailService.Infrastructure/EmailService.Infrastructure.csproj", "src/EmailService.Infrastructure/"]
COPY ["src/EmailService.Domain/EmailService.Domain.csproj", "src/EmailService.Domain/"]
RUN dotnet restore "./src/EmailService.Web/./EmailService.Web.csproj"
COPY . .
WORKDIR "/src/src/EmailService.Web"
RUN dotnet build "./EmailService.Web.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "./EmailService.Web.csproj" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailService.Web.dll"]