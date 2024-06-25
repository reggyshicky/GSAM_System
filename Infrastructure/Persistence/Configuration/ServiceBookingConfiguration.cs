using Domain.Entities.ServiceMngt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ServiceBookingConfiguration : IEntityTypeConfiguration<ServiceBooking>
    {
        public void Configure(EntityTypeBuilder<ServiceBooking> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProviderPostal).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ProviderEmail).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Status).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Comments).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.ProviderAccountNumber).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ProviderPhoneNumber).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Status).HasMaxLength(15).IsRequired(false);
            builder.Property(x => x.BookedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.VerifiedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.RejectedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.ClosedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.ApproverComments).HasMaxLength(1000).IsRequired(false);
        }
    }
}
