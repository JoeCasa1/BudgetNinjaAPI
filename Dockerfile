FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BudgetNinjaAPI.csproj", "./"]
RUN dotnet restore "BudgetNinjaAPI.csproj"
COPY . .
RUN dotnet publish "BudgetNinjaAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BudgetNinjaAPI.dll"]
