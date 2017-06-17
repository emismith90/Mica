FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet Mica.Presntation.Web.dll  
ENTRYPOINT ["dotnet", "Mica.Presentation.Web.dll"]
