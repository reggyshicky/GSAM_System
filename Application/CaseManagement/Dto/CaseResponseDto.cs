namespace Application.CaseManagement.Dto;

public record CaseResponseDto(int CaseNumber,
                              string? CifId,
                              string? AccountName,
                              decimal LoanAmount,
                              int LoanTenure,
                              string? SolId,
                              decimal LoanBalance,
                              string? LoanAccount,
                              char SyndicatedFlag,
                              char VerifiedFlag,
                              char Assigned,
                              string? AssignedEmail,
                              string? Status,
                              char RecoveredFlag,
                              char RestructuredFlag,
                              char RefinancedFlag,
                              string ApproverRemarks);

