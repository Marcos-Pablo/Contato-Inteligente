FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /DockerSource

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Api/*.csproj ./Api/
RUN dotnet restore

# Copy everything else and build website
COPY Api/. ./Api/
WORKDIR /DockerSource/Api
RUN dotnet publish -c release -o /DockerOutput/Website --no-restore

# Final stage / image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /DockerOutput/Website
COPY --from=build /DockerOutput/Website ./
# ENTRYPOINT ["dotnet", "Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Api.dll