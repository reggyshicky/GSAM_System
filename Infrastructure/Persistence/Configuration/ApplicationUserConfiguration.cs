using Domain.Entities.UserMngt;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PfNumber).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(30).IsRequired();
            builder.Property(x => x.DeletedBy).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Role).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.ActivatedBy).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.DeactivatedBy).HasMaxLength(200).IsRequired(false);
        }
    }
}
