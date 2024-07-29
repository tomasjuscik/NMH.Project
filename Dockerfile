FROM mcr.microsoft.com/dotnet/aspnet:8.0.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NMH.Project.Api/NMH.Project.Api.csproj", "NMH.Project.Api/"]
COPY ["NMH.Project.sln", "./"]
COPY . .
RUN dotnet build "NMH.Project.Api/NMH.Project.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NMH.Project.Api/NMH.Project.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS="http://+"

ENTRYPOINT ["dotnet", "NMH.Project.Api.dll"]