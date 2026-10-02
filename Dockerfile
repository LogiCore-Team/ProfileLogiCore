# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["Portflio/Portflio.csproj", "Portflio/"]
RUN dotnet restore "Portflio/Portflio.csproj"

# Copy source code
COPY . .

# Publish
WORKDIR "/src/Portflio"
RUN dotnet publish "Portflio.csproj" -c Release -o /app/publish /p:UseAppHost=false


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Render uses port 10000 by default
ENV ASPNETCORE_HTTP_PORTS=10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "Portflio.dll"]
