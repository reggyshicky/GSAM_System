using Domain.Entities.ServiceMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;
public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
{
    public void Configure(EntityTypeBuilder<ServiceProvider> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
        builder.Property(x => x.AccountNumber).HasMaxLength(200).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Postal).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.CreatedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
    }
}
