namespace Application.ServiceManagement.Dto
{
    public class ServiceBookingDto
    {
        public int ServiceId { get; set; }
        public int ServiceProviderId { get; set; }

        public int RegionId { get; set; }
        public string ProviderEmail { get; set; }
        public string ProviderPostal { get; set; }

        public string ProviderPhoneNumber { get; set; }

        public string ProviderAccountNumber { get; set; }
        public string Comments { get; set; }
        public string? ApproverComments { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
