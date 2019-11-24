FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Pdgt.BookApi/Pdgt.BookApi.csproj", "Pdgt.BookApi/"]
RUN dotnet restore "Pdgt.BookApi/Pdgt.BookApi.csproj"
COPY . .
WORKDIR "/src/Pdgt.BookApi"
RUN dotnet build "Pdgt.BookApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pdgt.BookApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pdgt.BookApi.dll"]