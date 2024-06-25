using Application.Common;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Commands
{
    public record DeleteServiceCommand(int Id) : IRequest<APIResponse<Unit>>;

    public sealed class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public DeleteServiceCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var thecase = await _db.ServiceBookings.FirstOrDefaultAsync(u => u.Id == request.Id && u.DeletedFlag == 'N', cancellationToken);
            if (thecase == null)
            {
                return new APIResponse<Unit>
                {
                    Message = $"Case with number {request.Id} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            thecase.DeletedFlag = 'Y';
            thecase.DeletedBy = _user.GetCurrentUserName();
            thecase.DeletedTime = DateTime.Now;
            await _db.SaveChangesAsync(cancellationToken);
            return new APIResponse<Unit>
            {
                Message = $"Case {thecase.Id} deleted succesfully",
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}
