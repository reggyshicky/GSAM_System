using Application.CaseManagement.Dto.RecoverDtos;
using Application.Common;
using Application.Models;
using Application.RestructureManagement.Dtos;
using AutoMapper;
using Domain.Entities.RecoverMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.RecoverCommands
{
    public record DeleteRecoverCommand(int CaseNumber) : IRequest<APIResponse<RecoverResponseDto>>;

    public sealed class DeleteRecoverCommandHandler : IRequestHandler<DeleteRecoverCommand, APIResponse<RecoverResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public DeleteRecoverCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }

        public async Task<APIResponse<RecoverResponseDto>> Handle(DeleteRecoverCommand request, CancellationToken cancellationToken)
        {
            var thecase = await _db.Recovers.FirstOrDefaultAsync(r => r.CaseNumber == request.CaseNumber, cancellationToken);
            if (thecase == null)
            {
                return new APIResponse<RecoverResponseDto>
                {
                    Message = $"Recover case with number {request.CaseNumber} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            thecase.DeletedFlag = 'Y';
            thecase.DeletedBy = _user.GetCurrentUserName();
            thecase.DeletedTime = DateTime.Now;
            await _db.SaveChangesAsync(cancellationToken);

            return new APIResponse<RecoverResponseDto>
            {
                Message = $"Recover case {thecase.CaseNumber} deleted succesfully",
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}
