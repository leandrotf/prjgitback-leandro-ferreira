#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["prjslnback.API/prjslnback.API.csproj", "prjslnback.API/"]
RUN dotnet restore "prjslnback.API/prjslnback.API.csproj"
COPY . .
WORKDIR "/src/prjslnback.API"
RUN dotnet build "prjslnback.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "prjslnback.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "prjslnback.API.dll"]