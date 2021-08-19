using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        private readonly string connectionString = "Server=127.0.0.1; Port=5432; Database=taskManagerConsole; User Id=oleg; Password=123;";

        public MyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseNpgsql(connectionString);

            return new MyDbContext(builder.Options);
        }
    }
}