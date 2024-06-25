using Domain.Entities.RestructureMgnt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class RestructureConfiguration : IEntityTypeConfiguration<Restructure>
    {
        public void Configure(EntityTypeBuilder<Restructure> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CifID).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LoanAccount).HasMaxLength(300).IsRequired();
            builder.Property(x => x.AccountName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.SolId).HasMaxLength(30).IsRequired();
            builder.Property(x => x.NewLoanTenure).IsRequired();
            builder.Property(x => x.LoanTenure).IsRequired();
            builder.Property(x => x.Comments).IsRequired();
            builder.Property(x => x.NewInstalments).HasColumnType("money").IsRequired();
            builder.Property(x => x.LoanAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.InitialInstalments).HasColumnType("money").IsRequired();
            builder.Property(x => x.LoanAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.RestructuredBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);
            builder.HasIndex(x => x.LoanAccount).IsUnique();
            builder.Property(x => x.ApproverRemarks).HasMaxLength(600).IsRequired(false);
        }
    }
}
