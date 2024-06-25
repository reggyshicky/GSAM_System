using Application.ClaimManagement.InternalClaim.Commands;
using Application.ClaimManagement.InternalClaim.Dto;
using Application.ClaimManagement.InternalClaim.Queries;
using Application.Models;
using Application.RefinanceMngt.Dto;
using Application.RefinanceMngt.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.ClaimMngtController
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalController : ControllerBase
    {
        private readonly ISender _sender;
        public InternalController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("AddClaim")]
        public async Task<ActionResult<APIResponse<InternalResponseDto>>> AddClaim([FromBody] AddInternalCommand request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetCreatedClaims")]
        public async Task<ActionResult<APIResponse<List<InternalResponseDto>>>> GetCreatedClaims([FromQuery] GetInternalClaimsQuery request) =>
          Ok(await _sender.Send(request));
    }
}
