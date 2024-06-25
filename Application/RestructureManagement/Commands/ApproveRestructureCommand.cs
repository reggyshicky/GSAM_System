using Application.Common;
using Application.Models;
using Application.RestructureManagement.Dtos;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Commands
{
    public sealed record ApproveRestructureCommand(int CaseNumber, string ApproverRemarks) : IRequest<APIResponse<RestructureResponseDto>>;

    public sealed class ApproveRestructureCommandHandler : IRequestHandler<ApproveRestructureCommand, APIResponse<RestructureResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public ApproveRestructureCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<RestructureResponseDto>> Handle(ApproveRestructureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var thecase = await _db.Restructures.FirstOrDefaultAsync(x => x.CaseNumber == request.CaseNumber);
                if (thecase != null)
                {
                    if (thecase.VerifiedFlag == 'N')
                    {
                        thecase.ApproverRemarks = request.ApproverRemarks;
                        thecase.VerifiedBy = _user.GetCurrentUserName();
                        thecase.VerifiedTime = DateTime.Now;
                        thecase.VerifiedFlag = 'Y';
                        await _db.SaveChangesAsync();
                        return new APIResponse<RestructureResponseDto>
                        {
                            Message = $"The Restructured Case with  CaseNumber : {request.CaseNumber} has been approved succesfully",
                            StatusCode = HttpStatusCode.OK,
                        };
                    }
                    else
                    {
                        return new APIResponse<RestructureResponseDto>
                        {
                            Message = $"The RestructuredCase with  CaseNumber : {request.CaseNumber} has already been approved",
                            StatusCode = HttpStatusCode.BadRequest,
                        };
                    }
                }
                else
                {
                    return new APIResponse<RestructureResponseDto>
                    {
                        Message = $"The RestructuredCase with CaseNumber : {request.CaseNumber} does not exist",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<RestructureResponseDto>
                {
                    Message = $"Error occurred while approving the Restructured with CaseNumber : {request.CaseNumber}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
