namespace Application.ServiceManagement.Dto
{
    public class BookingResponse
    {
        public int RequestId;
        public string ServiceName;
        public string RegionName;
        public string ServiceProviderName;
        public string ProviderPhoneNumber;
        public string ProviderAccountNumber;
        public string ProviderEmail;
        public DateTime ServiceDate;
        public string Comments;
        public string Status;
        public char DeletedFlag;
    }
}
