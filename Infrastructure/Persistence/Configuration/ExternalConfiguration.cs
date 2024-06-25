
using Domain.Entities.ClaimMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ExternalConfiguration : IEntityTypeConfiguration<External>
    {
        public void Configure(EntityTypeBuilder<External> builder)
        {
            builder.HasKey(x => x.Id );
            builder.Property(x => x.ServiceProvider).HasMaxLength(30).IsRequired();
            builder.Property(x => x.ServiceName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.AccountNumber).HasMaxLength(30).IsRequired();
            builder.Property(x => x.ClaimAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.EmailAddress).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ClaimRequestDetails).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ApproverRemarks).HasMaxLength(600).IsRequired(false);
            builder.Property(x => x.CreatedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);

        }
    }
}
