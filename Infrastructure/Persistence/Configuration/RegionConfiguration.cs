using Domain.Entities.ServiceMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RegionName).HasMaxLength(400).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(400).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(400).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(400).IsRequired(false);
            builder.HasIndex(x => x.RegionName).IsUnique();
        }
    }
}
