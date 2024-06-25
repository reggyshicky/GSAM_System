using Domain.Entities.RefinanceMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class RefinanceConfiguration : IEntityTypeConfiguration<Refinance>
    {
        public void Configure(EntityTypeBuilder<Refinance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CifID).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LoanAccount).HasMaxLength(300).IsRequired();
            builder.Property(x => x.AccountName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.SolId).HasMaxLength(30).IsRequired();
            builder.Property(x => x.NewLoanTenure).IsRequired();
            builder.Property(x => x.LoanTenure).IsRequired();
            builder.Property(x => x.Comments).IsRequired();
            builder.Property(x => x.InitialInstalments).HasColumnType("money").IsRequired();
            builder.Property(x => x.NewInstalments).HasColumnType("money").IsRequired();
            builder.Property(x => x.LoanAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.RefinanceAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.LoanAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.RefinancedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.ApproverRemarks).HasMaxLength(600).IsRequired(false);
            builder.HasIndex(x => x.LoanAccount).IsUnique();
        }
    }
}
