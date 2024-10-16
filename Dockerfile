# Use the ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files first to take advantage of Docker's caching
COPY ["LojaGamerM/LojaGamerM.csproj", "LojaGamerM/"]
COPY ["LojaGamerM.Bussines/LojaGamerM.Bussines.csproj", "LojaGamerM.Bussines/"]
COPY ["LojaGamerM.Models/LojaGamerM.Models.csproj", "LojaGamerM.Models/"]

# Restore dependencies
RUN dotnet restore "LojaGamerM/LojaGamerM.csproj"

# Copy the rest of the application code
COPY . .

# Build the project
RUN dotnet build "LojaGamerM/LojaGamerM.csproj" -c Release -o /app/build


RUN dotnet restore "LojaGamerM/LojaGamerM.csproj"

# Publish the project
FROM build AS publish
RUN dotnet publish "LojaGamerM/LojaGamerM.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage to create the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaGamerM.dll"]
