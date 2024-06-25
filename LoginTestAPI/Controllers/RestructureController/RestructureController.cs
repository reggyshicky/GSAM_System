using Application.CaseManagement.Commands;
using Application.Models;
using Application.RefinanceMngt.Dto;
using Application.RestructureManagement.Commands;
using Application.RestructureManagement.Dtos;
using Application.RestructureManagement.Queries;
using LoginTestAPI.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.RestructureController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestructureController : ControllerBase
    {
        private readonly ISender _sender;
        public RestructureController(ISender send)
        {
            _sender = send;
        }

        [HttpPost]
        [Route("CaseRestructure")]
        public async Task<ActionResult<APIResponse<Unit>>> Restructure([FromBody] AddRestructureCommand request) =>
            Ok(await _sender.Send(request));

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<APIResponse<RestructureResponseDto>>> DeleteRestructuredCase([FromQuery] DeleteRestructureCommand request) =>
            Ok(await _sender.Send(request));


        [HttpGet]
        [Route("GetAllRestructuredCases")]
        public async Task<ActionResult<APIResponse<List<RestructureResponseDto>>>> GetAllCases([FromQuery] GetAllRestructuredQuery request) =>
            Ok(await _sender.Send(request));


        [HttpPost]
        [Route("CalculateLoanTenure")]
        public ActionResult<APIResponse<object>> CalculateLoanTenure(decimal RemainingLoanAmount, decimal newloanMontlyInstallments)
        {
            var _tenureCalculator = new LoanTenureCalculator();
            return Ok(_tenureCalculator.CalculateLoanTenure(RemainingLoanAmount, newloanMontlyInstallments));
        }


        [HttpPost]
        [Route("ApproveRestructureCase")]
        public async Task<ActionResult<APIResponse<RestructureResponseDto>>> ApproveRestructrueCase([FromBody] ApproveRestructureCommand request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetApprovedRestructuredCases")]
        public async Task<ActionResult<APIResponse<List<RestructureResponseDto>>>> GetApproevedRestructuredCases([FromQuery] GetApprovedRestructuredCasesQuery request) =>
           Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetUnApprovedRestructuredCases")]
        public async Task<ActionResult<APIResponse<List<RestructureResponseDto>>>> GetUnApprovedRestructuredCases([FromQuery] GetUnApprovedRestructuredCasesQuery request) =>
           Ok(await _sender.Send(request));
    }
}
