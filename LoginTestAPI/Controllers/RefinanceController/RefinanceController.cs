using Application.CaseManagement.Commands;
using Application.Models;
using Application.RefinanceMngt.Commands;
using Application.RefinanceMngt.Dto;
using Application.RefinanceMngt.Queries;
using Application.RestructureManagement.Dtos;
using Application.RestructureManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace CaseManagement.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefinanceController : ControllerBase
    {
        private readonly ISender _sender;
        public RefinanceController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("Refinance")]
        public async Task<ActionResult<APIResponse<RefinanceDto>>> Refinance([FromBody] AddRefinanceCommand request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetRefinancedCases")]
        public async Task<ActionResult<APIResponse<List<RefinanceDto>>>> GetRefinancedCases([FromQuery] GetRefinancesQuery request) =>
          Ok(await _sender.Send(request));

        [HttpPost]
        [Route("ApproveRefinancedCase")]
        public async Task<ActionResult<APIResponse<RefinanceDto>>> ApproveRefinanceCase([FromBody] ApproveRefinanceCommand request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetApprovedRefinancedCases")]
        public async Task<ActionResult<APIResponse<List<RefinanceDto>>>> GetApproevedRestructuredCases([FromQuery] GetApprovedRefinancedCasesQuery request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetUnApprovedRefinancedCases")]
        public async Task<ActionResult<APIResponse<List<RefinanceDto>>>> GetUnApprovedRestructuredCases([FromQuery] GetUnApprovedRefinancedCasesQuery request) =>
           Ok(await _sender.Send(request));

    }
}
