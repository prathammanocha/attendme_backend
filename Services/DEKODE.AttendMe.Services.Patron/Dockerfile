#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/DEKODE.AttendMe.Services.Patron/DEKODE.AttendMe.Services.Patron.csproj", "Services/DEKODE.AttendMe.Services.Patron/"]
RUN dotnet restore "Services/DEKODE.AttendMe.Services.Patron/DEKODE.AttendMe.Services.Patron.csproj"
COPY . .
WORKDIR "/src/Services/DEKODE.AttendMe.Services.Patron"
RUN dotnet build "DEKODE.AttendMe.Services.Patron.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DEKODE.AttendMe.Services.Patron.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DEKODE.AttendMe.Services.Patron.dll"]