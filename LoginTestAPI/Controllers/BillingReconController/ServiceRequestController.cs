using Application.CaseManagement.Commands;
using Application.CaseManagement.Dto;
using Application.DocumentManagement.Commands;
using Application.Models;
using Application.ServiceManagement.Commands;
using Application.ServiceManagement.Dto;
using Application.ServiceManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.BillingReconController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly ISender _sender;
        public ServiceRequestController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("AddService")]
        public async Task<ActionResult<APIResponse<Unit>>> AddService([FromBody] AddServiceCommand request) =>
            Ok(await _sender.Send(request));

        //[Authorize]
        [HttpPost]
        [Route("AddRegion")]
        public async Task<ActionResult<APIResponse<Unit>>> AddRegion([FromBody] AddRegionCommand request) =>
          Ok(await _sender.Send(request));

        [HttpPost]
        [Route("BookService")]
        public async Task<ActionResult<APIResponse<Unit>>> BookService([FromBody] AddServiceBookingCommand request) =>
            Ok(await _sender.Send(request));

        [HttpPost]
        [Route("AddServiceProvider")]
        public async Task<ActionResult<APIResponse<Unit>>> AddServiceProviders([FromBody] AddServiceProviderCommand request) =>
        Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetAllServices")]
        public async Task<ActionResult<APIResponse<List<ServiceResponseDto>>>> GetAllServices([FromQuery] GetAllServicesQuery request) =>
            Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetAllRegions")]
        public async Task<ActionResult<APIResponse<List<ServiceResponseDto>>>> GetAllRegion([FromQuery] GetAllRegionsQuery request) =>
           Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetAllServiceProviders")]
        public async Task<ActionResult<APIResponse<List<ServiceResponseDto>>>> GetAllServiceProviders([FromQuery] GetAllServiceProviderQuery request) =>
           Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetAllRequests")]
        public async Task<ActionResult<APIResponse<List<BookingResponse>>>> GetAllRequests([FromQuery] GetAllRequestsQuery request) =>
           Ok(await _sender.Send(request));

        [HttpPost]
        [Route("ApproveRequest")]
        public async Task<ActionResult<APIResponse<Unit>>> ApproveRequest([FromBody] AddVerifyCommand request) =>
       Ok(await _sender.Send(request));


        [HttpPost]
        [Route("RejectRequest")]
        public async Task<ActionResult<APIResponse<Unit>>> RejectRequest([FromBody] AddRejectCommand request) =>
            Ok(await _sender.Send(request));


        [HttpDelete]
        [Route("DeleteServiceBooking")]
        public async Task<ActionResult<APIResponse<Unit>>> DeleteServiceBooking([FromBody] DeleteServiceCommand request) =>
            Ok(await _sender.Send(request));

        [HttpPatch]
        [Route("UpdateRequest")]
        public async Task<ActionResult<APIResponse<CaseResponseDto>>> UpdateRequest([FromQuery] int Id, JsonPatchDocument<ServiceBookingDto> patchDocument)
        {
            var command = new UpdateServiceBoookingCommand(Id, patchDocument);
            return Ok(await _sender.Send(command));
        }


        [HttpPost]
        [Route("BookingDocumentUpload")]
        public async Task<ActionResult<APIResponse<object>>> Upload([FromForm] BookingDocumentCommand request) =>
            Ok(await _sender.Send(request));
    }
}
