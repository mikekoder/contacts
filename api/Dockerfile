FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Contacts.Api/Contacts.Api.csproj", "Contacts.Api/"]
RUN dotnet restore "Contacts.Api/Contacts.Api.csproj"
COPY . .
WORKDIR "/src/Contacts.Api"
RUN dotnet build "Contacts.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Contacts.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Contacts.Api.dll"]