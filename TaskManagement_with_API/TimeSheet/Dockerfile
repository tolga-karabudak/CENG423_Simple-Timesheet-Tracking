#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TimeSheet/TimeSheet.csproj", "TimeSheet/"]
RUN dotnet restore "TimeSheet/TimeSheet.csproj"
COPY . .
WORKDIR "/src/TimeSheet"
RUN dotnet build "TimeSheet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeSheet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeSheet.dll"]