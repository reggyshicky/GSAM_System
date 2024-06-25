using Application.CaseManagement.Commands;
using Application.CaseManagement.Dto;
using Application.CaseManagement.Dto.RecoverDtos;
using Application.CaseManagement.Queries;
using Application.CaseManagement.Queries.RecoverCaseQueries;
using Application.DocumentManagement.Commands;
using Application.DocumentManagement.Queries;
using Application.FileManagement.Dtos;
using Application.Models;
using Application.RestructureManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.DocumentsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentMgntController : ControllerBase
    {
        private readonly ISender _sender;
        public DocumentMgntController(ISender send)
        {
            _sender = send;
        }

        
        [HttpPost]
        [Route("DocumentUpload")]
        public async Task<ActionResult<APIResponse<Unit>>> Upload([FromForm] UploadDocumentCommand request) =>
            Ok(await _sender.Send(request));


        [HttpGet]
        [Route("GetAllDocuments")]
        public async Task<ActionResult<APIResponse<DocumentResponseDto>>> GetAllDocuments([FromQuery] GetAllDocumentsQuery request) =>
           Ok(await _sender.Send(request));

        [HttpGet]
        [Route("GetDocumentByLoanAccount")]
        public async Task<ActionResult<APIResponse<DocumentResponseDto>>> GetDocumentByLoanAccount([FromQuery] GetDocumentByLoanAccount request) =>
        Ok(await _sender.Send(request));


        [HttpPost]
        [Route("ApproveUploadedDocument")]
        public async Task<ActionResult<APIResponse<DocumentResponseDto>>> ApproveUploadedDocumnet([FromBody] ApproveUploadedDocumentCommand request) =>
           Ok(await _sender.Send(request));

        [HttpPost]
        [Route("RejectUploadedDocument")]
        public async Task<ActionResult<APIResponse<DocumentResponseDto>>> RejectUploadedDocumnet([FromBody] RejectUploadedDocumentCommand request) =>
          Ok(await _sender.Send(request));



        [HttpGet]
        [Route("GetDocumentById")]

        public async Task<ActionResult<APIResponse<DocumentResponseDto>>> GetDocumentById([FromQuery] GetDocumentByIdQuery request) =>
            Ok(await _sender.Send(request));


        [HttpGet]
        [Route("GetUnApprovedDocuments")]
        public async Task<ActionResult<APIResponse<DocumentResponseDto>>> GetUnApprovedDocuments([FromQuery] GetUnApprovedDocumentsQuery request) =>
           Ok(await _sender.Send(request));
    }
}
