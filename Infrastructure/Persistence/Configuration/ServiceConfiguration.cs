using Domain.Entities.ServiceMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ServiceName).HasMaxLength(400).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(400).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(400).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(400).IsRequired(false);
            builder.HasIndex(x => x.ServiceName).IsUnique();
        }
    }
}
