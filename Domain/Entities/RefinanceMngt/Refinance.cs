namespace Domain.Entities.RefinanceMngt;

public class Refinance
{
    public int Id { get; set; }
    public string CifID { get; set; } = string.Empty;
    public string LoanAccount { get; set; } = string.Empty;
    public int CaseNumber { get; set; }
    public decimal LoanBalance { get; set; }
    public decimal LoanAmount { get; set; }
    public string Comments { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public string SolId { get; set; } = string.Empty;
    public decimal InitialInstalments { get; set; }
    public decimal RefinanceAmount { get; set; }
    public decimal NewInstalments { get; set; }
    public int LoanTenure { get; set; }
    public int NewLoanTenure { get; set; }

    public string ApproverRemarks { get; set; } = string.Empty;
    public char RefinancedFlag { get; set; } = 'N';
    public string? RefinancedBy { get; set; }
    public DateTime RefinancedTime { get; set; }

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
