using TaskManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.Data.Configuration
{
    public class StatusConfigurations : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("statuses");
            
            builder.Property(e => e.StatusId)
                .HasColumnName("status_id");

            builder.Property(e => e.StatusName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("status_name");
        }
    }
}