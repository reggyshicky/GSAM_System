namespace Domain.Entities.ServiceMngt
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Postal { get; set; }
        public string Email { get; set; } = string.Empty;
        public int ServiceId { get; set; }
        public int RegionId { get; set; }
        public Service Service { get; set; }
        public Region Region { get; set; }
        public char CreatedFlag { get; set; } = 'N';
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }

        public string? ModifiedBy { get; set; }
        public char ModifiedFlag { get; set; } = 'N';
        public DateTime ModifiedTime { get; set; }

        public string? DeletedBy { get; set; }
        public char DeletedFlag { get; set; } = 'N';
        public DateTime DeletedTime { get; set; }
    }
}
