# taskManager

### 
1) dotnet tool install --global dotnet-ef
    - (dotnet new tool-manifest)
    - (dotnet tool install dotnet-ef)
    
### Подключаемые пакеты:
1) dotnet add package Microsoft.EntityFrameworkCore.Design
2) dotnet add package Microsoft.EntityFrameworkCore.Tools
3) dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

### Проверка базы данных и просмотр sql кода миграции:
1) dotnet ef dbcontext info
2) dotnet ef migrations script

### Разработка базы данных

#### Code First
1) dotnet ef migrations add MigrationName
2) dotnet ef database update

БАЗА ДАННЫХ ПЕРВАЯ
1) dotnet ef dbcontext scaffold "Server=127.0.0.1; Port=5432; Database=databaseName; User Id=userName; Password=password;" Npgsql.EntityFrameworkCore.PostgreSQL
