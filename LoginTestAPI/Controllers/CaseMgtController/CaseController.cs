using Application.CaseManagement.Commands;
using Application.CaseManagement.Dto;
using Application.CaseManagement.Queries;
using Application.CsseManagement.Dtos;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.CaseMgtController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<CaseController> _logger;
        public CaseController(ISender sender, ILogger<CaseController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateCase")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> CreateCase([FromBody] AddCaseCommand request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetCaseByCaseNumber")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetCaseByCaseNumber([FromQuery] GetByCaseNumberQuery request) =>
         Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetCaseByCif")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetCaseByCif([FromQuery] GetByCifQuery request) =>
            Ok(await _sender.Send(request));

        //[Authorize]
        [HttpGet]
        [Route("GetAllCases")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetAllCases([FromQuery] GetAllCasesQuery request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetAssignedCases")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetAssignedCases([FromQuery] GetAssignedCasesQuery request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetUnAssignedCases")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetUnassignedCases([FromQuery] GetUnAssignedCasesQuery request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("ActiveCases")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetActiveCases([FromQuery] GetActiveCasesQuery request) =>
           Ok(await _sender.Send(request));

        [HttpGet]
        [Route("ClosedCases")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetClosedCases([FromQuery] GetClosedCasesQuery request) =>
           Ok(await _sender.Send(request));

        [HttpDelete]
        [Route("DeleteCase")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> DeleteCase([FromBody] DeleteCaseCommand request) =>
            Ok(await _sender.Send(request));

        //[Authorize(Roles = "Admin, Hr")]
        [HttpPost]
        [Route("AssignCase")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> AssignCase([FromQuery] AssignCaseCommand request) =>
            Ok(await _sender.Send(request));

        [HttpPatch]
        [Route("UpdateCase")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> UpdateCase([FromQuery] int caseNumber, JsonPatchDocument<UpdateDto> patchDocument)
        {
            var command = new UpdateCaseCommand(caseNumber, patchDocument);
            return Ok(await _sender.Send(command));
        }

        [HttpPost]
        [Route("ApproveCase")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> ApproveCase([FromBody] ApproveCaseCommand request) =>
            Ok(await _sender.Send(request));

        //[Authorize]
        [HttpGet]
        [Route("GetUnApprovedCases")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> GetUnapprovedCases([FromQuery] GetUnApprovedCasesQuery request) =>
            Ok(await _sender.Send(request));

    }
}
