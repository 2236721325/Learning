#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAPI_Publish/WebAPI_Publish.csproj", "WebAPI_Publish/"]
RUN dotnet restore "WebAPI_Publish/WebAPI_Publish.csproj"
COPY . .
WORKDIR "/src/WebAPI_Publish"
RUN dotnet build "WebAPI_Publish.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI_Publish.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI_Publish.dll"]