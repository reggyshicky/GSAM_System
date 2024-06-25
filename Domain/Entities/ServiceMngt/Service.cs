namespace Domain.Entities.ServiceMngt
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;

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
