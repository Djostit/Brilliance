FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCOREURLS=http://+80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Brilliance.API/Brilliance.API.csproj", "Brilliance.API/"]
COPY ["Brilliance.Database/Brilliance.Database.csproj", "Brilliance.Database/"]
COPY ["Brilliance.Domain/Brilliance.Domain.csproj", "Brilliance.Domain/"]
RUN dotnet restore "Brilliance.API/Brilliance.API.csproj"
COPY . .
WORKDIR "/src/Brilliance.API"
RUN dotnet build "Brilliance.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Brilliance.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brilliance.API.dll"]