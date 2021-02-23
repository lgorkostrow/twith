# .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
COPY *.sln .
COPY ./src/Twith.API/Twith.API.csproj ./Twith.API/
COPY ./src/Twith.Application/Twith.Application.csproj ./Twith.Application/
COPY ./src/Twith.Domain/Twith.Domain.csproj ./Twith.Domain/
COPY ./src/Twith.Infrastructure/Twith.Infrastructure.csproj ./Twith.Infrastructure/

# .NET Core Restore
RUN dotnet restore ./Twith.API/Twith.API.csproj

# Copy All Files
COPY ./src ./

# .NET Core Build and Publish
RUN dotnet publish ./Twith.API/Twith.API.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./
EXPOSE 80
#EXPOSE 443
ENTRYPOINT ["dotnet", "Twith.API.dll"]