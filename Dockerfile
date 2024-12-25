# build stage

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

RUN apt-get update && \
    apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_16.x | bash - && \
    apt-get install -y nodejs && \
    apt-get clean

RUN ls -la /src

COPY . .

RUN ls
WORKDIR /src/JinxDebtTracker

RUN npm i
RUN dotnet restore JinxDebtTracker.csproj --disable-parallel

RUN dotnet publish JinxDebtTracker.csproj -c release -o /app --no-restore
# serve stage

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
#COPY --from=build /https/aspnetapp.pfx /https/aspnetapp.pfx
WORKDIR /app
COPY --from=build /app .

EXPOSE 443 

ENTRYPOINT ["dotnet", "JinxDebtTracker.dll"]