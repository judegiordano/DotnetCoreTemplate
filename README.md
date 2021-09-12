## cli
```sh
dotnet new webapi
dotnet new gitignore
dotnet add package <package name>
dotnet tool install --global dotnet-ef # for dotnet ef
```

## user secrets
```
dotnet user-secrets init
dotnet user-secrets set <key> <value>
dotnet user-secrets list
dotnet user-secrets remove <key>
dotnet user-secrets clear
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
```

## [Nuget Registry]("https://www.nuget.org/)

## Running Locally
```
dotnet user-secrets set "WebApiTemplate:ConnectionString" <ssms connection string>
```