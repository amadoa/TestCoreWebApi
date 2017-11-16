FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENV LD_LIBRARY_PATH /root/.nuget/packages/IBM.Data.DB2.Core-lnx/1.1.1.101/build/clidriver/lib
ENTRYPOINT ["dotnet", "TestCoreWebApi.dll"]
