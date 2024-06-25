using Domain.Entities.CaseMgnt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;
public class CaseConfiguration : IEntityTypeConfiguration<Case>
{
    public void Configure(EntityTypeBuilder<Case> builder)
    {
        builder.HasKey(x => x.CaseNumber);
        builder.Property(x => x.CifId).HasMaxLength(30).IsRequired();
        builder.Property(x => x.AccountName).HasMaxLength(300).IsRequired();
        builder.Property(x => x.LoanAccount).HasMaxLength(30).IsRequired();
        builder.Property(x => x.SolId).HasMaxLength(30).IsRequired();
        builder.Property(x => x.LoanAmount).HasColumnType("money").IsRequired();
        builder.Property(x => x.LoanBalance).HasColumnType("money").IsRequired();
        builder.Property(x => x.LoanTenure).IsRequired();
        builder.Property(x => x.Status).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.AssignedEmail).HasMaxLength(200).IsRequired(false);
        builder.Property(x => x.AssignedId).HasMaxLength(450).IsRequired(false);
        builder.Property(x => x.AssignedBy).HasMaxLength(200).IsRequired(false);
        builder.Property(x => x.CreatedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.ClosedBy).HasMaxLength(30).IsRequired(false);
        builder.HasIndex(p => p.LoanAccount).IsUnique();
        builder.Property(x => x.ApproverRemarks).HasMaxLength(1000).IsRequired(false);
    }
}
