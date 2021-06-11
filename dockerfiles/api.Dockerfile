FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /src

COPY ["./meetupguider-api/src/MeetupGuider.API/", "MeetupGuider.API/"]
COPY ["./meetupguider-api/src/MeetupGuilder.Entities", "MeetupGuilder.Entities/"]
COPY ["./meetupguider-api/src/MeetupGuilder.Services", "MeetupGuilder.Services/"]
COPY ./meetupguider-api/src/MeetupGuider.API/MeetupGuider.API.sln .

RUN dotnet restore "MeetupGuider.API/MeetupGuider.API/MeetupGuider.API.csproj"
COPY . .
WORKDIR "/src/MeetupGuider.API"
RUN dotnet build "MeetupGuider.API/MeetupGuider.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeetupGuider.API/MeetupGuider.API.csproj" -c Release -o /app/publish

FROM base AS final

ENV ASPNETCORE_URLS=http://*:8080
ENV URLS=http://*:8080

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeetupGuider.API.dll"]