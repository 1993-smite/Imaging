#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebImages/WebImages.csproj", "WebImages/"]
COPY ["ImageCore/ImageCore.csproj", "ImageCore/"]
RUN dotnet restore "WebImages/WebImages.csproj"
COPY . .
WORKDIR "/src/WebImages"
RUN dotnet build "WebImages.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "WebImages.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebImages.dll"]