namespace Application.ClaimManagement.InternalClaim.Dto
{
    public record InternalResponseDto
    {
        public string StaffPF { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public decimal ClaimAmount { get; set; } = decimal.Zero;
        public string EmailAddress { get; set; } = string.Empty;
        public string ClaimRequestDetails { get; set; } = string.Empty;
        public string CreatedBy { get; set; }
    }
}
