

namespace Application.CaseManagement.Dto.RecoverDtos
{

    public record RecoverResponseDto
    {
        public string CifId { get; set; }
        public string LoanAccount { get; set; }
        public int CaseNumber { get; set; }
        public string Comments { get; set; }
        public string AccountName { get; set; }
        public string SolId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal LoanPaid { get; set; }
        public decimal LoanBalance { get; set; }
        public int MonthsInDefault { get; set; }
        public char RecoveredFlag { get; set; } = 'N';




        // Default constructor with optional arguments
        public RecoverResponseDto(
            string cifId = "",
            string loanAccount = "",
            string comments = "",
            string accountName = "",
            string solId = "",
            int caseNumber = 0,
            decimal loanAmount = 0,
            decimal loanPaid = 0,
            decimal loanBalance = 0,
            int monthsInDefault = 0,
            char recoveredFlag = 'N')

        {
            CifId = cifId;
            LoanAccount = loanAccount;
            CaseNumber = caseNumber;
            Comments = comments;
            AccountName = accountName;
            SolId = solId;
            LoanAmount = loanAmount;
            LoanPaid = loanPaid;
            LoanBalance = loanBalance;
            MonthsInDefault = monthsInDefault;
            RecoveredFlag = recoveredFlag;
        }
    }
}








