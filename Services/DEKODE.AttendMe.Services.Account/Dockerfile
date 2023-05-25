#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/DEKODE.AttendMe.Services.Account/DEKODE.AttendMe.Services.Account.csproj", "Services/DEKODE.AttendMe.Services.Account/"]
RUN dotnet restore "Services/DEKODE.AttendMe.Services.Account/DEKODE.AttendMe.Services.Account.csproj"
COPY . .
WORKDIR "/src/Services/DEKODE.AttendMe.Services.Account"
RUN dotnet build "DEKODE.AttendMe.Services.Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DEKODE.AttendMe.Services.Account.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DEKODE.AttendMe.Services.Account.dll"]