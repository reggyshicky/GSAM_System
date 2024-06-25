namespace Domain.Entities.ServiceMngt
{
    public class BookingDocument
    {
        public int Id { get; set; }
        public int ServiceBookingId { get; set; }
        public string Folder { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public DateTime UploadedTime { get; set; }
        public char UploadedFlag { get; set; } = 'N';

        public string VerifiedBy { get; set; } = string.Empty;
        public DateTime VerifiedTime { get; set; }
        public char VerifiedFlag { get; set; } = 'N';

        public string DeletedBy { get; set; } = string.Empty;
        public DateTime DeletedTime { get; set; }
        public char DeletedFlag { get; set; } = 'N';

        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedTime { get; set; }
        public char ModifiedFlag { get; set; } = 'N';

        public string RejectedBy { get; set; } = string.Empty;
        public DateTime RejectedTime { get; set; }
        public char RejectedFlag { get; set; } = 'N';
    }
}
