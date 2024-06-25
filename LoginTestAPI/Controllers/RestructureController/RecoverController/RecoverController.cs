using Application.CaseManagement.Dto;
using Application.CaseManagement.Dto.RecoverDtos;
using Application.CaseManagement.Queries;
using Application.CaseManagement.Queries.RecoverCaseQueries;
using Application.CaseManagement.RecoverCommands;
using Application.Models;
using Application.RestructureManagement.Commands;
using Application.RestructureManagement.Dtos;
using LoginTestAPI.Controllers.CaseMgtController;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.RecoverController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecoverController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<CaseController> _logger;
        public RecoverController(ISender sender, ILogger<CaseController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost]
        [Route("CaseRecover")]
        public async Task<ActionResult<APIResponse<Unit>>> Recover([FromBody] AddRecoverCommand request) =>
            Ok(await _sender.Send(request));

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<APIResponse<RecoverResponseDto>>> DeleteRecoveredCase([FromQuery] DeleteRecoverCommand request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetAllRecoverCases")]
        public async Task<ActionResult<APIResponse<RecoverResponseDto>>> GetAllCases([FromQuery] GetAllRecoverCases request) =>
            Ok(await _sender.Send(request));
    }
}
