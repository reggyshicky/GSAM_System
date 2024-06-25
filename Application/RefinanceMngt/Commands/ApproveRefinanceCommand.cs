using Application.Common;
using Application.Models;
using Application.RefinanceMngt.Dto;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Commands
{
    public sealed record ApproveRefinanceCommand(int CaseNumber, string ApproverRemarks) : IRequest<APIResponse<RefinanceDto>>;

    public sealed class ApproveRefinanceCommandHandler : IRequestHandler<ApproveRefinanceCommand, APIResponse<RefinanceDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public ApproveRefinanceCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<RefinanceDto>> Handle(ApproveRefinanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var thecase = await _db.Refinances.FirstOrDefaultAsync(x => x.CaseNumber == request.CaseNumber);
                if (thecase != null)
                {
                    if (thecase.VerifiedFlag == 'N')
                    {
                        thecase.ApproverRemarks = request.ApproverRemarks;
                        thecase.VerifiedBy = _user.GetCurrentUserName();
                        thecase.VerifiedTime = DateTime.Now;
                        thecase.VerifiedFlag = 'Y';
                        await _db.SaveChangesAsync();
                        return new APIResponse<RefinanceDto>
                        {
                            Message = $"The Refinanced Case with  CaseNumber : {request.CaseNumber} has been approved succesfully",
                            StatusCode = HttpStatusCode.OK,
                        };
                    }
                    else
                    {
                        return new APIResponse<RefinanceDto>
                        {
                            Message = $"The Refinanced Case with  CaseNumber : {request.CaseNumber} has already been approved",
                            StatusCode = HttpStatusCode.BadRequest,
                        };
                    }
                }
                else
                {
                    return new APIResponse<RefinanceDto>
                    {
                        Message = $"The Refinanced Case with CaseNumber : {request.CaseNumber} does not exist",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<RefinanceDto>
                {
                    Message = $"Error occurred while approving the Refinanced Case with CaseNumber : {request.CaseNumber}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
