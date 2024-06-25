using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.RecoverMngt
{
    public class Recover
    {
        //tea
        public int Id { get; set; }
        public string CifID { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public int CaseNumber { get; set; }

        public string Comments { get; set; } = string.Empty;
        public string LoanAccount { get; set; } = string.Empty;
        public string SolId { get; set; } = string.Empty;

        public decimal LoanAmount { get; set; }
        public decimal LoanPaid { get; set; }
        public decimal LoanBalance { get; set; }
        public int MonthsInDefault { get; set; }

        public char RecoveredFlag { get; set; } = 'N';
        public string? RecoveredBy { get; set; }
        public DateTime RecoveredTime { get; set; }

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
