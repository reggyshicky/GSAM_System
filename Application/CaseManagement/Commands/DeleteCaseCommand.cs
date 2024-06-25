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
    public record DeleteCaseCommand(int CaseNumber) : IRequest<APIResponse<CaseResponseDto>>;

    public sealed class DeleteCaseCommandHandler : IRequestHandler<DeleteCaseCommand, APIResponse<CaseResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public DeleteCaseCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<CaseResponseDto>> Handle(DeleteCaseCommand request, CancellationToken cancellationToken)
        {
            var thecase = await _db.Cases.FirstOrDefaultAsync(u => u.CaseNumber == request.CaseNumber && u.DeletedFlag == 'N', cancellationToken);
            if (thecase == null)
            {
                return new APIResponse<CaseResponseDto>
                {
                    Message = $"Case with number {request.CaseNumber} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            thecase.DeletedFlag = 'Y';
            thecase.DeletedBy = _user.GetCurrentUserName();
            thecase.DeletedTime = DateTime.Now;
            await _db.SaveChangesAsync(cancellationToken);
            return new APIResponse<CaseResponseDto>
            {
                Message = $"Case {thecase.CaseNumber} deleted succesfully",
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}
