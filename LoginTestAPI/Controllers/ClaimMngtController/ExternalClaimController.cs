using Application.ClaimManagement.ExternalClaim.Commands;
using Application.ClaimManagement.ExternalClaim.Dto;
using Application.ClaimManagement.ExternalClaim.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LoginTestAPI.Controllers.ClaimMngtController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalClaimController : ControllerBase
    {
        private readonly ISender _sender;
        public ExternalClaimController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("AddClaim")]
        public async Task<ActionResult<APIResponse<ExternalResponseDto>>> AddClaim([FromBody] AddExternalCommand request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetCreatedClaims")]
        public async Task<ActionResult<APIResponse<List<ExternalResponseDto>>>> GetCreatedClaims([FromQuery] GetExternalClaimsQuery request) =>
          Ok(await _sender.Send(request));
    }
}