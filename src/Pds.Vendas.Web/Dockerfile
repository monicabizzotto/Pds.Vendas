FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Pds.Vendas.Web/Pds.Vendas.Web.csproj", "Pds.Vendas.Web/"]
RUN dotnet restore "Pds.Vendas.Web/Pds.Vendas.Web.csproj"
COPY . .
WORKDIR "/src/Pds.Vendas.Web"
RUN dotnet build "Pds.Vendas.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pds.Vendas.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pds.Vendas.Web.dll"]