using Application.Common;
using Application.Models;
using Application.RestructureManagement.Dtos;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.RestructureManagement.Commands
{
    public record DeleteRestructureCommand(int CaseNumber) : IRequest<APIResponse<RestructureResponseDto>>;

    public sealed class DeleteRestructureCommandHandler : IRequestHandler<DeleteRestructureCommand, APIResponse<RestructureResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _user;
        public DeleteRestructureCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _user = user;
        }
        public async Task<APIResponse<RestructureResponseDto>> Handle(DeleteRestructureCommand request, CancellationToken cancellationToken)
        {
            var thecase = await _db.Restructures.FirstOrDefaultAsync(u => u.CaseNumber == request.CaseNumber && u.DeletedFlag == 'N', cancellationToken);
            if (thecase == null)
            {
                return new APIResponse<RestructureResponseDto>
                {
                    Message = $"Restructured case with number {request.CaseNumber} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            thecase.DeletedFlag = 'Y';
            thecase.DeletedBy = _user.GetCurrentUserName();
            thecase.DeletedTime = DateTime.Now;
            await _db.SaveChangesAsync(cancellationToken);

            return new APIResponse<RestructureResponseDto>
            {
                Message = $"Restructured case {thecase.CaseNumber} deleted succesfully",
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}
