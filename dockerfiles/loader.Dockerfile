FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /src

COPY ["./meetupguider-api/src/RSVPLoader/", "RSVPLoader/"]
COPY ["./meetupguider-api/src/MeetupGuilder.Entities", "MeetupGuilder.Entities/"]
COPY ./rsvp-loader/src/RSVPLoader/RSVPLoader.sln .

RUN dotnet restore "RSVPLoader/RSVPLoader/RSVPLoader.csproj"
COPY . .
WORKDIR "/src/RSVPLoader"
RUN dotnet build "RSVPLoader/RSVPLoader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RSVPLoader/RSVPLoader.csproj" -c Release -o /app/publish

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RSVPLoader.dll"]