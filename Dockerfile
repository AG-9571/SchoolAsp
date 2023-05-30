FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app

COPY . /app

EXPOSE 2000

CMD dotnet run --project /app/school.csproj --urls=http://0.0.0.0:2000RJG