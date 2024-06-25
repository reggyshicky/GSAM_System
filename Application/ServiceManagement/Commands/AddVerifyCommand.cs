using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.ValueObjects;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.ServiceManagement.Commands
{
    public record AddVerifyCommand(string ApproverComments, int RequestId) : IRequest<APIResponse<Unit>>;

    public sealed class AddVerifyCommandHandler : IRequestHandler<AddVerifyCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _user;

        public AddVerifyCommandHandler(ApplicationDbContext db, ICurrentUser user)
        {
            _db = db;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(AddVerifyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var booking = await _db.ServiceBookings.FirstOrDefaultAsync(x => x.Id == request.RequestId);
                if (booking != null)
                {
                    booking.VerifiedBy = _user.GetCurrentUserName();
                    booking.VerifiedTime = DateTime.Now;
                    booking.VerifiedFlag = 'Y';
                    booking.ApproverComments = request.ApproverComments;
                    booking.Status = ServiceBookingStatus.Approved.ToString();
                    await _db.SaveChangesAsync();
                    return new APIResponse<Unit>
                    {
                        Message = $"The Request with Id : {request.RequestId} has been approved succesfully",
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
                    Message = $"Error occurred while approving the Request with Id : {request.RequestId}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
