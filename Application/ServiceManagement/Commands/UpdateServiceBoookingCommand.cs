using Application.Common;
using Application.Models;
using Application.ServiceManagement.Dto;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Commands
{
    public record UpdateServiceBoookingCommand(int Id, JsonPatchDocument<ServiceBookingDto> PatchDocument) : IRequest<APIResponse<BookingResponse>>;


    public sealed class UpdateServiceBoookingCommandHandler : IRequestHandler<UpdateServiceBoookingCommand, APIResponse<BookingResponse>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public UpdateServiceBoookingCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<BookingResponse>> Handle(UpdateServiceBoookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _db.ServiceBookings.AsNoTracking().FirstOrDefaultAsync(u => u.Id == request.Id);

            if (booking == null)
            {
                return new APIResponse<BookingResponse>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Request with RequestId {request.Id} not found"
                };
            }
            //Map the existing case to an update DTO
            var serviceBookingDto = _mapper.Map<ServiceBookingDto>(booking);

            //Apply the patch document to the update DTO
            request.PatchDocument.ApplyTo(serviceBookingDto);

            //Map the updated properties from the DTO back to the existing case entity
            _mapper.Map(serviceBookingDto, booking);

            booking.ModifiedBy = _user.GetCurrentUserName();
            booking.ModifiedFlag = 'Y';
            booking.ModifiedTime = DateTime.Now;
            booking.VerifiedFlag = 'N';
            _db.ServiceBookings.Update(booking);
            await _db.SaveChangesAsync();
            return new APIResponse<BookingResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Message = $"Case {request.Id} updated succesfully",
                Result = _mapper.Map<BookingResponse>(booking)
            };
        }
    }
}
