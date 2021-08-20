# TaskManager

## Предисловие
В данном решени представлена только часть задания отвечающая за: создание базы данных, подключение к базе данных, а также написан маленький кусочек кода демонстрирующий создание новых строк таблиц БД и вывод таблиц в конколь.  
Заранее извиняюсь за качество работы, данная консольная программа должна была быть тестовым образцом, на котором были бы отработаны: 
- способы создания базы данных по коду
- создание кода по уже существующей БД
- создание миграций, и кроверка того как одна миграция дополняет предшевтующую
В дальнейшем я хотел перенести код с некоторыми изменениями в ASP.NET Core и добавить там элементы веб интерфейса описанные в техническом задании, но изучение основ слишком затянулось.



## Работа с командной строкой (в директории проекта)

### Создание консольного решения
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
