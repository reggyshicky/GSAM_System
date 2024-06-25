

namespace Application.ClaimManagement.ExternalClaim.Dto
{
    public record ExternalResponseDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string ServiceProvider { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public decimal ClaimAmount { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime ServiceDate { get; set; }
        public string ClaimRequestDetails { get; set; } = string.Empty;
        public string ApproverRemarks { get; set; } = string.Empty;
    }
}
