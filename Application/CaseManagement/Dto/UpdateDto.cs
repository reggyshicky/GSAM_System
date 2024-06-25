namespace Application.CsseManagement.Dtos
{
    public class UpdateDto
    {
        public string CifId { get; set; }
        public string AccountName { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal LoanBalance { get; set; }
        public string LoanAccount { get; set; }
        public int LoanTenure { get; set; }
        public char SyndicatedFlag { get; set; }
    }
}
