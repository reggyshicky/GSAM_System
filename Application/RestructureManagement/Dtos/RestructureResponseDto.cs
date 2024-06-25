namespace Application.RestructureManagement.Dtos
{
    public record RestructureResponseDto(string CifID,
                                         string AccountName,
                                         string LoanAccount,
                                         int CaseNumber,
                                         string Comments,
                                         string SolId,
                                         decimal LoanBalance,
                                         decimal InitialInstalments,
                                         decimal NewInstalments,
                                         int LoanTenure,
                                         int NewLoanTenure,
                                         char VerifiedFlag,
                                         string ApproverRemarks);
}
