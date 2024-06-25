using Domain.Entities.ServiceMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class BookingDocumentConfiguration : IEntityTypeConfiguration<BookingDocument>
    {
        public void Configure(EntityTypeBuilder<BookingDocument> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Folder).HasMaxLength(300).IsRequired();
            builder.Property(x => x.FilePath).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ModifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.VerifiedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.RejectedBy).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.UploadedBy).HasMaxLength(30).IsRequired(false);
        }
    }
}
