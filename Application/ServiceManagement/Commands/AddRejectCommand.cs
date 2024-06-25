using Application.Common;
using Application.Models;
using Domain.ValueObjects;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.ServiceManagement.Commands
{
    public record AddRejectCommand(string ApproverComments, int RequestId) : IRequest<APIResponse<Unit>>;

    public sealed class AddRejectCommandHandler : IRequestHandler<AddRejectCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _user;

        public AddRejectCommandHandler(ApplicationDbContext db, ICurrentUser user)
        {
            _db = db;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(AddRejectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var booking = await _db.ServiceBookings.FirstOrDefaultAsync(x => x.Id == request.RequestId);
                if (booking != null)
                {
                    booking.RejectedBy = _user.GetCurrentUserName();
                    booking.RejectedTime = DateTime.Now;
                    booking.RejectedFlag = 'Y';
                    booking.ApproverComments = request.ApproverComments;
                    booking.Status = ServiceBookingStatus.Rejected.ToString();
                    await _db.SaveChangesAsync();
                    return new APIResponse<Unit>
                    {
                        Message = $"The Request with Id : {request.RequestId} has been rejected",
                        StatusCode = HttpStatusCode.OK,
                    };

                }
                else
                {
                    return new APIResponse<Unit>
                    {
                        Message = $"The Request with Id : {request.RequestId} does not exist",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Unit>
                {
                    Message = $"Error occurred while rejecting the Request with Id : {request.RequestId}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
