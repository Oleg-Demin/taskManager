using EFCore.Entitis;
using EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusConfigurations());
            modelBuilder.ApplyConfiguration(new TaskConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}