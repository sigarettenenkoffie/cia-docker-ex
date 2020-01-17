FROM mcr.microsoft.com/dotnet/core/sdk:2.2
LABEL version="1.0"
LABEL author="Christof Becu"
LABEL description="Examen Part 1"
WORKDIR /app
COPY bin/Debug/netcoreapp2.2/publish .
ENTRYPOINT [ "dotnet","ExamWeb.dll" ]