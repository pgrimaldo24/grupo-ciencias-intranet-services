#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base 
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GrupoCiencias.Intranet.Api/GrupoCiencias.Intranet.Api.csproj", "GrupoCiencias.Intranet.Api/"]
COPY ["GrupoCiencias.Intranet.Repository.Implementations/GrupoCiencias.Intranet.Repository.Implementations.csproj", "GrupoCiencias.Intranet.Repository.Implementations/"]
COPY ["GrupoCiencias.Intranet.Repository.Interfaces/GrupoCiencias.Intranet.Repository.Interfaces.csproj", "GrupoCiencias.Intranet.Repository.Interfaces/"]
COPY ["GrupoCiencias.Intranet.Domain.Models/GrupoCiencias.Intranet.Domain.Models.csproj", "GrupoCiencias.Intranet.Domain.Models/"]
COPY ["GrupoCiencias.Intranet.CrossCutting.Common/GrupoCiencias.Intranet.CrossCutting.Common.csproj", "GrupoCiencias.Intranet.CrossCutting.Common/"]
COPY ["GrupoCiencias.Intranet.CrossCutting.Dto/GrupoCiencias.Intranet.CrossCutting.Dto.csproj", "GrupoCiencias.Intranet.CrossCutting.Dto/"]
COPY ["GrupoCiencias.Intranet.CrossCutting.IoC/GrupoCiencias.Intranet.CrossCutting.IoC.csproj", "GrupoCiencias.Intranet.CrossCutting.IoC/"]
COPY ["GrupoCiencias.Intranet.Application.Implementations/GrupoCiencias.Intranet.Application.Implementations.csproj", "GrupoCiencias.Intranet.Application.Implementations/"]
COPY ["GrupoCiencias.Intranet.Application.Interfaces/GrupoCiencias.Intranet.Application.Interfaces.csproj", "GrupoCiencias.Intranet.Application.Interfaces/"]
RUN dotnet restore "GrupoCiencias.Intranet.Api/GrupoCiencias.Intranet.Api.csproj"
COPY . .
WORKDIR "/src/GrupoCiencias.Intranet.Api"
RUN dotnet build "GrupoCiencias.Intranet.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrupoCiencias.Intranet.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrupoCiencias.Intranet.Api.dll"]