using Domain.Entities.UserMngt;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities.CaseMgnt;

public class Case
{
    public int CaseNumber { get; set; }
    public string CifId { get; set; } = string.Empty;

    public string AccountName { get; set; } = string.Empty;

    public decimal LoanAmount { get; set; }

    public decimal LoanBalance { get; set; }

    public string LoanAccount { get; set; } = string.Empty;

    public int LoanTenure { get; set; }

    public string SolId { get; set; } = string.Empty;
    public string ApproverRemarks { get; set; } = string.Empty;

    public char SyndicatedFlag { get; set; } = 'N';
    public string? Status { get; set; }
    public char Assigned { get; set; } = 'N';
    public string? AssignedEmail { get; set; }
    public string? AssignedId { get; set; }

    [ForeignKey("AssignedId")]
    public ApplicationUser? AssignedEmployee { get; set; }
    public string? AssignedBy { get; set; }

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

    public string? ClosedBy { get; set; }
    public DateTime CloseTime { get; set; }

    public char RestructuredFlag { get; set; } = 'N';

    public char RefinancedFlag { get; set; } = 'N';

    public char RecoveredFlag { get; set; } = 'N';
}


