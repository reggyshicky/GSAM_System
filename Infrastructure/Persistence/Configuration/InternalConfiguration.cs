
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.ClaimMngt;

namespace Infrastructure.Persistence.Configuration
{
    public class InternalConfiguration : IEntityTypeConfiguration<Internal>
    {
        public void Configure(EntityTypeBuilder<Internal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StaffPF).HasMaxLength(30).IsRequired();
            builder.Property(x => x.StaffName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.AccountNumber).HasMaxLength(30).IsRequired();
            builder.Property(x => x.ClaimAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.EmailAddress).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ClaimRequestDetails).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ApproverRemarks).HasMaxLength(600).IsRequired(false);
            builder.Property(x => x.CreatedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);
            

        }
    }
}
