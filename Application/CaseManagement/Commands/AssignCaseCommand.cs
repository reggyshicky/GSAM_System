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
    public record AssignCaseCommand(int CaseNumber,
                                    string UserName) : IRequest<APIResponse<CaseResponseDto>>;

    public sealed class AssignCaseCommandHandler : IRequestHandler<AssignCaseCommand, APIResponse<CaseResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _user;
        public AssignCaseCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _mapper = mapper;
            _db = db;
            _user = user;
        }
        public async Task<APIResponse<CaseResponseDto>> Handle(AssignCaseCommand request, CancellationToken cancellationToken)
        {
            var assignedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);
            if (assignedUser == null)
            {
                return new APIResponse<CaseResponseDto>
                {
                    Message = $"User with {request.UserName} does not exist",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            else
            {
                var thecase = await _db.Cases.FirstOrDefaultAsync(u => u.CaseNumber == request.CaseNumber);
                if (thecase != null)
                {
                    thecase.Assigned = 'Y';
                    thecase.AssignedEmail = assignedUser.UserName;
                    thecase.AssignedId = assignedUser.Id;
                    thecase.AssignedBy = _user.GetCurrentUserName();
                    await _db.SaveChangesAsync();
                    return new APIResponse<CaseResponseDto>
                    {
                        Message = $"Case {request.CaseNumber} assigned succesfully to user {request.UserName}",
                        StatusCode = HttpStatusCode.OK,
                        Result = _mapper.Map<CaseResponseDto>(thecase)
                    };
                }
                else
                {
                    return new APIResponse<CaseResponseDto>
                    {
                        Message = $"Case {request.CaseNumber} being assigned does not exist",
                        StatusCode = HttpStatusCode.OK,
                    };
                }
            }
        }
    }
}
