FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 1000

ENV ASPNETCORE_URLS=http://+:1000

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
ARG configuration=Release
WORKDIR /src

COPY ["./Voyages.SqlDataAccess/Voyages.SqlDataAccess.csproj", "./Voyages.SqlDataAccess/"]
RUN dotnet restore "Voyages.SqlDataAccess/Voyages.SqlDataAccess.csproj"

COPY ["./Voyages.Domain/Voyages.Domain.csproj", "./Voyages.Domain/"]
RUN dotnet restore "Voyages.Domain/Voyages.Domain.csproj"

COPY ["./Voyages.WebApi/Voyages.WebApi.csproj", "./Voyages.WebApi/"]
RUN dotnet restore "Voyages.WebApi/Voyages.WebApi.csproj"

COPY ./Voyages.SqlDataAccess ./Voyages.SqlDataAccess
COPY ./Voyages.Domain ./Voyages.Domain
COPY ./Voyages.WebApi ./Voyages.WebApi

WORKDIR "/src/."
RUN dotnet build "Voyages.WebApi/Voyages.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Voyages.WebApi/Voyages.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Voyages.WebApi.dll"]

WORKDIR /app
COPY ["./Voyages.WebApi/sqlite.db", "./"]