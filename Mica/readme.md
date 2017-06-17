
#compose
dotnet restore ./Mica.sln
dotnet publish ./Mica.sln -c Release -o ./obj/Docker/publish


docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" -f "docker-compose.vs.debug.yml" -p dockercompose20170618 build
docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" -f "docker-compose.vs.debug.yml" -p dockercompose20170618 up -d