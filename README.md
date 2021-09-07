# TaskManager

## Важно!
GitHub не загружает репозиторий /obj (пока не знаю как это решить). Если вы собираетесь запустить программу, в данном проекте присутствует сжатый архив "TaskManager.tar.gz". Разархивировав его вы получите сам проект (включающий репозеторий /obj) и пример базы данных используемой в задаче (данная БД не обязательна, она служит всего лишь примером того как будет выглядеть БД проекта и какие данные туда можно вносить).

## Предисловие
Данное тестовое задание сделано на основании ASP.NET MVC, так как я, по глупости, думал что Web Api контроллекы и методы составляют малую часть задания и делаются в конце. Дойдя до них, я понял что необходимо либо полностью переделывать задание или внедрять в MVC еще и WebApi. Второй вариант спорный, как я понял, при таком выходе из ситуации в одной программе будет 2 контролллера взаимодействия с одной и той же базой данных (WebApi на стороне клиента проводит запросы к БД, MVC на стороне сервера), или же мы заменяем контроллек на Api контроллер? Я не очень уверен в своих размышлениях, и прошу, если будет возможность обратной связи, рассказать как на самом деле они могут взаимодействовать.  

В итоге я просто оставил версию ASP.NET MVC. Это повлекло за собой то, что данные главной таблицы обновляются вместе со всей страницей (это не так критично).  

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
