using Domain.Entities.DocumentMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Domain.Entities.DocumentMngt.Documents>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.DocumentMngt.Documents> builder)
        {
           builder.HasKey(x => x.Id); 
           builder.Property(x => x.FileName).HasMaxLength(200).IsRequired();
           builder.Property(x => x.Folder).HasMaxLength(300).IsRequired();
            builder.Property(x => x.AccountName).HasMaxLength(400).IsRequired();
           builder.Property(x => x.FileExtension).HasMaxLength(300).IsRequired(); 
           builder.Property(x => x.FilePath).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Comments).HasMaxLength(600).IsRequired();
           builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
           builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
           builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
           builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);


        }
    }
}
