FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 2000

ENV ASPNETCORE_URLS=http://+:2000

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
ARG configuration=Release
WORKDIR /src

COPY ["./Voyages.Domain/Voyages.Domain.csproj", "./Voyages.Domain/"]
RUN dotnet restore "Voyages.Domain/Voyages.Domain.csproj"

COPY ["./Voyages.GraphQL.Api/Voyages.GraphQL.Api.csproj", "./Voyages.GraphQL.Api/"]
RUN dotnet restore "Voyages.GraphQL.Api/Voyages.GraphQL.Api.csproj"

COPY ./Voyages.Domain ./Voyages.Domain
COPY ./Voyages.GraphQL.Api ./Voyages.GraphQL.Api

WORKDIR "/src/."
RUN dotnet build "Voyages.GraphQL.Api/Voyages.GraphQL.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Voyages.GraphQL.Api/Voyages.GraphQL.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Voyages.GraphQL.Api.dll"]
