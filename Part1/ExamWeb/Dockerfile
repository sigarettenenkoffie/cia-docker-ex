FROM mcr.microsoft.com/dotnet/core/sdk:2.2
LABEL version="1.0"
LABEL author="Christof Becu"
LABEL description="Examen Part 1"
WORKDIR /examweb
COPY . .
RUN dotnet publish -o /publish
WORKDIR /publish
ENTRYPOINT [ "dotnet","/publish/ExamWeb.dll" ]