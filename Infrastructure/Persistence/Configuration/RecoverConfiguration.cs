using Domain.Entities.RecoverMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class RecoverConfiguration : IEntityTypeConfiguration<Recover>
    {
      
        public void Configure(EntityTypeBuilder<Recover> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CifID).HasMaxLength(30);
            builder.Property(x => x.LoanAccount).HasMaxLength(300).IsRequired();
            builder.Property(x => x.AccountName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.SolId).HasMaxLength(30).IsRequired();
            builder.Property(x => x.CaseNumber).HasMaxLength(200).IsRequired();
            builder.Property(x => x.MonthsInDefault).IsRequired();
            builder.Property(x => x.Comments).IsRequired();
            builder.Property(x => x.LoanAmount).HasColumnType("money").IsRequired();
            builder.Property(x => x.LoanPaid).HasColumnType("money").IsRequired();
            builder.Property(x => x.LoanBalance).HasColumnType("money").IsRequired();
            builder.Property(x => x.RecoveredBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);
        }
    }
}
