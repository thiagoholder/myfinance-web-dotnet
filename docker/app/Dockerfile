# Imagem base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copia csproj e restaura dependências
COPY ./*.sln  .
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

RUN dotnet nuget locals all --clear
RUN dotnet restore MyFinance.sln

# Copia tudo e faz build da aplicação
COPY . .
RUN dotnet publish src/WebApp/WebApp.csproj -c Release -o ./out

# Gera imagem final
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out /app/

ENTRYPOINT ["dotnet", "WebApp.dll"]