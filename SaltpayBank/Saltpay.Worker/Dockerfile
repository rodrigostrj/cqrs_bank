#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Saltpay.Worker/Saltpay.Worker.csproj", "Saltpay.Worker/"]
RUN dotnet restore "Saltpay.Worker/Saltpay.Worker.csproj"
COPY . .
WORKDIR "/src/Saltpay.Worker"
RUN dotnet build "Saltpay.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Saltpay.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Saltpay.Worker.dll", "--environment=Development"]