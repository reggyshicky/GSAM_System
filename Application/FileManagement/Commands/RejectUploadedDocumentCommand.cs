using Application.Common;
using Application.FileManagement.Dtos;
using Application.Models;
using AutoMapper;
using Domain.Entities.DocumentMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.DocumentManagement.Commands
{
    public sealed record RejectUploadedDocumentCommand(int Id, string Comments) : IRequest<APIResponse<DocumentResponseDto>>;

    public sealed class RejectUploadedDocumentCommandHandler : IRequestHandler<RejectUploadedDocumentCommand, APIResponse<DocumentResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public RejectUploadedDocumentCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }

        public async Task<APIResponse<DocumentResponseDto>> Handle(RejectUploadedDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var document = await _db.Documents.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (document != null)
                {
                    if (document.RejectedFlag == 'N' && document.VerifiedFlag== 'N')
                    {
                        document.RejectedBy = _user.GetCurrentUserName();
                        document.RejectedTime = DateTime.Now;
                        document.RejectedFlag = 'Y';
                        document.Comments = request.Comments;
                        await _db.SaveChangesAsync(cancellationToken);

                        var documentResponse = _mapper.Map<DocumentResponseDto>(document);
                        return new APIResponse<DocumentResponseDto>
                        {
                            Message = $"The Document with ID : {request.Id} has been Rejected successfully",
                            StatusCode = HttpStatusCode.OK,
                            Result = documentResponse
                        };
                    }
                    else
                    {
                        return new APIResponse<DocumentResponseDto>
                        {
                            Message = $"The Document with ID : {request.Id} has already been Rejected",
                            StatusCode = HttpStatusCode.BadRequest,
                        };
                    }
                }
                else
                {
                    return new APIResponse<DocumentResponseDto>
                    {
                        Message = $"The Document with ID : {request.Id} does not exist",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<DocumentResponseDto>
                {
                    Message = $"Error occurred while approving the Document with ID : {request.Id}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
