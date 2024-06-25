using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.ServiceMngt;
using Domain.ValueObjects;
using Infrastructure.Data;
using MediatR;
using System.Net;


namespace Application.ServiceManagement.Commands
{
    public record AddServiceBookingCommand(int ServiceId,
                                           int RegionId,
                                           int ServiceProviderId,
                                           string ProviderPhoneNumber,
                                           string ProviderAccountNumber,
                                           string ProviderEmail,
                                           string Comments,
                                           DateTime ServiceDate,
                                           string ProviderPostal) : IRequest<APIResponse<Unit>>;

    public sealed class AddServingBoookingComamandHandler : IRequestHandler<AddServiceBookingCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public AddServingBoookingComamandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(AddServiceBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var domainModel = _mapper.Map<ServiceBooking>(request);
                domainModel.BookedBy = _user.GetCurrentUserName();
                domainModel.BookingFlag = 'Y';
                domainModel.BookedTime = DateTime.Now;
                domainModel.Status = ServiceBookingStatus.Active.ToString();
                domainModel.Status = ServiceBookingStatus.Pending.ToString();
                await _db.ServiceBookings.AddAsync(domainModel, cancellationToken);
                await _db.SaveChangesAsync();

                return new APIResponse<Unit>
                {
                    Message = $"Service with Request ID {domainModel.Id} booked succesfully!",
                    StatusCode = HttpStatusCode.Created
                };

            }
            catch (Exception ex)
            {
                return new APIResponse<Unit>
                {
                    Message = "Error occurred while booking a service",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }


        }
    }
}
