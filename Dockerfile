# ---------- STAGE 1: Build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

#Copy project file and restore dependecies
COPY src/DockerDemo.API/DockerDemo.API.csproj ./DockerDemo.API/
RUN dotnet restore ./DockerDemo.API/DockerDemo.API.csproj

# Copy everything else and build
COPY src/DockerDemo.API ./DockerDemo.API
WORKDIR /src/DockerDemo.API
RUN dotnet publish -c Release -o /app/publish

# ---------- STAGE 2: Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# Expose port
EXPOSE 8080

# Set environment
ENV ASPNETCORE_URLS=http://+:8080

# Start application
ENTRYPOINT ["dotnet", "DockerDemo.API.dll"]





 