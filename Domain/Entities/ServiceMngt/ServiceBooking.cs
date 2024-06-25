namespace Domain.Entities.ServiceMngt
{
    public class ServiceBooking
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ServiceProviderId { get; set; }

        public int RegionId { get; set; }
        public string ProviderEmail { get; set; } = string.Empty;
        public string ProviderPostal { get; set; } = string.Empty;

        public string ProviderPhoneNumber { get; set; } = string.Empty;

        public string ProviderAccountNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public string Comments { get; set; } = string.Empty;

        public string? ApproverComments { get; set; }
        public DateTime ServiceDate { get; set; }
        public char BookingFlag { get; set; } = 'N';
        public string? BookedBy { get; set; }
        public DateTime BookedTime { get; set; }

        public string? ModifiedBy { get; set; }
        public char ModifiedFlag { get; set; } = 'N';
        public DateTime ModifiedTime { get; set; }

        public string? VerifiedBy { get; set; }
        public char VerifiedFlag { get; set; } = 'N';

        public DateTime VerifiedTime { get; set; }

        public string? DeletedBy { get; set; }
        public char DeletedFlag { get; set; } = 'N';
        public DateTime DeletedTime { get; set; }

        public char RejectedFlag { get; set; } = 'N';
        public string? RejectedBy { get; set; }
        public DateTime RejectedTime { get; set; }

        public string? ClosedBy { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
