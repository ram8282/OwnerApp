# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and publish the app
COPY . . 
RUN dotnet restore
RUN dotnet publish -c Release -o out

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Start the application
ENTRYPOINT ["dotnet", "OwnerApp.dll"]