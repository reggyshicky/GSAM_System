using Application.CaseManagement.Dto;
using Application.Common;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Commands
{
    public sealed record ApproveCaseCommand(int CaseNumber, string ApproverRemarks) : IRequest<APIResponse<CaseResponseDto>>;

    public sealed class ApproveCaseCommandHandler : IRequestHandler<ApproveCaseCommand, APIResponse<CaseResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public ApproveCaseCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<CaseResponseDto>> Handle(ApproveCaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var thecase = await _db.Cases.FirstOrDefaultAsync(x => x.CaseNumber == request.CaseNumber);
                if (thecase != null)
                {
                    if (thecase.VerifiedFlag == 'N')
                    {
                        thecase.ApproverRemarks = request.ApproverRemarks;
                        thecase.VerifiedBy = _user.GetCurrentUserName();
                        thecase.VerifiedTime = DateTime.Now;
                        thecase.VerifiedFlag = 'Y';
                        await _db.SaveChangesAsync();
                        return new APIResponse<CaseResponseDto>
                        {
                            Message = $"The Case with  CaseNumber : {request.CaseNumber} has been approved succesfully",
                            StatusCode = HttpStatusCode.OK,
                        };
                    }
                    else
                    {
                        return new APIResponse<CaseResponseDto>
                        {
                            Message = $"The Case with  CaseNumber : {request.CaseNumber} has already been approved",
                            StatusCode = HttpStatusCode.BadRequest,
                        };
                    }
                }
                else
                {
                    return new APIResponse<CaseResponseDto>
                    {
                        Message = $"The Case with CaseNumber : {request.CaseNumber} does not exist",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<CaseResponseDto>
                {
                    Message = $"Error occurred while approving the Case with Id : {request.CaseNumber}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
