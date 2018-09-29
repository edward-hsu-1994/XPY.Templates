FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["$safeprojectname$/$safeprojectname$.csproj", "$safeprojectname$/"]
RUN dotnet restore "$safeprojectname$/$safeprojectname$.csproj"
COPY . .
WORKDIR "/src/$safeprojectname$"
RUN dotnet build "$safeprojectname$.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "$safeprojectname$.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "$safeprojectname$.dll"]