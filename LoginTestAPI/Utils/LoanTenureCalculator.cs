using Application.Models;
using System.Net;

namespace LoginTestAPI.Utils
{
    public class LoanTenureCalculator
    {
        public APIResponse<object> CalculateLoanTenure(decimal RemainingLoanAmount, decimal newloanMontlyInstallments)
        {
            return new APIResponse<object>
            {
                Message = "New loan Tenure calculated",
                StatusCode = HttpStatusCode.OK,
                Result = RemainingLoanAmount / newloanMontlyInstallments
            };

        }
    }
}
