## cli
```sh
dotnet new webapi
dotnet new gitignore
dotnet add package <package name>
dotnet tool install --global dotnet-ef # for dotnet ef
dotnet clean
dotnet build
dotnet run
dotnet publish -c Release -o Out
```

## user secrets
```
dotnet user-secrets init
dotnet user-secrets set <key> <value>
dotnet user-secrets list
dotnet user-secrets remove <key>
dotnet user-secrets clear
dotnet dev-certs https --clean
dotnet dev-certs https
dotnet dev-certs https --trust
dotnet publish -c Release -o out
```

## ef cli
```sh
dotnet ef
dotnet ef migrations add <Migration Name>
dotnet ef migrations remove
dotnet ef database update
```

## template snippets
```sh
prop -> {TAB} # new class property
ctor -> {TAB} # class constructor
```

## docker
```
docker volume ls
docker volume prune
docker build -t webapitemplate .
docker run -d -p 8080:80 --name myapp webapitemplate
```

## Running Locally
```
dotnet user-secrets set "WebApiTemplate:ConnectionString" <ssms connection string>
```

## [Nuget Registry](https://www.nuget.org/)