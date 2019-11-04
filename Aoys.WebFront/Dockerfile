FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Aoys.WebFront.csproj", "Aoys.WebFront/"]
RUN dotnet restore "Aoys.WebFront.csproj"
COPY . .
WORKDIR "/src/Aoys.WebFront"
RUN dotnet build "Aoys.WebFront.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aoys.WebFront.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aoys.WebFront.dll"]