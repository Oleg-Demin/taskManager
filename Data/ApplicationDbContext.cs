using TaskManager.Models;
using TaskManager.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        public ApplicationDbContext()
        {
            // Database.EnsureCreated();
            // Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusConfigurations());
            modelBuilder.ApplyConfiguration(new TaskConfigurations());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5432; Database=taskManagerMVC; User Id=oleg; Password=123;");
        }
    }
}