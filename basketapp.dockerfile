FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/BasketApp.WebApi/BasketApp.WebApi.csproj", "src/BasketApp.WebApi/"]
COPY ["src/BasketApp.Application/BasketApp.Application.csproj", "src/BasketApp.Application/"]
COPY ["src/BasketApp.Domain/BasketApp.Domain.csproj", "src/BasketApp.Domain/"]
COPY ["src/BasketApp.Infrastructure/BasketApp.Infrastructure.csproj", "src/BasketApp.Infrastructure/"]
RUN dotnet restore "src/BasketApp.WebApi/BasketApp.WebApi.csproj"
COPY . .
WORKDIR "/src/src/BasketApp.WebApi"
RUN dotnet build "BasketApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketApp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketApp.WebApi.dll"]