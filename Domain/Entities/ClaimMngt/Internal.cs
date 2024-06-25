namespace Domain.Entities.ClaimMngt
{
    public class Internal
    {
        public int Id { get; set; } 
        public String StaffPF { get; set; } = string.Empty;
        public String StaffName { get; set; }= string.Empty;
        public String AccountNumber { get; set; } = string.Empty;
        public decimal ClaimAmount { get; set; } = decimal.Zero; 
        public String EmailAddress { get; set; } = string.Empty;
        public String ClaimRequestDetails { get; set; } = string.Empty;
        public string ApproverRemarks { get; set; } = string.Empty;
        public char CreatedFlag { get; set; } = 'N';
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }

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
    }

}
