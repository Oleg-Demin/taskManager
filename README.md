# TaskManager (Asp.NET Core MVC, Entity Framework)

## Предисловие
GitHub не загружает репозиторий /obj (пока не знаю как это решить). Если вы собираетесь запустить программу, в данном проекте присутствует сжатый архив "TaskManager.tar.gz". Разархивировав его вы получите сам проект (включающий репозеторий /obj) и пример базы данных используемой в задаче (данная БД не обязательна, она служит всего лишь примером того как будет выглядеть БД проекта и какие данные туда можно вносить).

## Используемая СУБД
postgres (PostgreSQL) 13.3

## Используемый редактор исходного кода
Visual Studio Code 1.60.0

## Работа с командной строкой (в директории проекта)

### Создание решения через консоль
- dotnet new console -o taskManager 

### Установка Entity Framework Core
#### Глобально
- dotnet tool install --global dotnet-ef
#### Локально
- dotnet new tool-manifest
- dotnet tool install dotnet-ef
    
### Подключаемые пакеты:
1) dotnet add package Microsoft.EntityFrameworkCore.Design
2) dotnet add package Microsoft.EntityFrameworkCore.Tools
3) dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

### Разработка базы данных
#### Code First
1) dotnet ef migrations add MigrationName
2) dotnet ef database update
#### Database first
- dotnet ef dbcontext scaffold "Server=127.0.0.1; Port=5432; Database=databaseName; User Id=userName; Password=password;" Npgsql.EntityFrameworkCore.PostgreSQL

### Проверка базы данных и просмотр sql кода миграции:
1) dotnet ef dbcontext info
2) dotnet ef migrations script

### Иные часто используемые команды:
- dotnet ef migrations remove
- dotnet ef database drop
