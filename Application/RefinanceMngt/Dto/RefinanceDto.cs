namespace Application.RefinanceMngt.Dto
{
    public class RefinanceDto
    {
        public string CifID { get; set; } = string.Empty;
        public string LoanAccount { get; set; } = string.Empty;
        public int CaseNumber { get; set; }
        public decimal LoanAmount { get; set; }
        public string SolId { get; set; } = string.Empty;
        public decimal InitialInstalments { get; set; }
        public decimal RefinanceAmount { get; set; }
        public decimal NewInstalments { get; set; }
        public int NewLoanTenure { get; set; }
        public string Comments { get; set; }
        public char VerifiedFlag { get; set; }

        public int LoanTenure { get; set; }
        public string AccountName { get; set; }
        public decimal LoanBalance { get; set; }

        public string ApproverRemarks { get; set; }

    }
}
