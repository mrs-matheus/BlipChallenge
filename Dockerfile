# Esta imagem é usada no modo de execução da aplicação (base).
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Esta imagem é usada para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Blip.Challenge.Api/Blip.Challenge.Api.csproj", "Blip.Challenge.Api/"]
COPY ["./Blip.Challenge/Blip.Challenge.Presentation/Blip.Challenge.Presentation.csproj", "Blip.Challenge.Presentation/"]
COPY ["./Blip.Challenge/Blip.Challenge.Domain/Blip.Challenge.Domain.csproj", "Blip.Challenge.Domain/"]
COPY ["./Blip.Challenge/Blip.Challenge.Repository/Blip.Challenge.Repository.csproj", "Blip.Challenge.Repository/"]
RUN dotnet restore "./Blip.Challenge.Api/Blip.Challenge.Api.csproj"
COPY . . 
WORKDIR "/src/Blip.Challenge.Api"
RUN dotnet build "./Blip.Challenge.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Esta etapa é usada para publicar o projeto.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Blip.Challenge.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Esta é a imagem final usada em produção.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blip.Challenge.Api.dll"]
