using Application.Models;
using Application.ServiceManagement.Dto;
using AutoMapper;
using Azure.Core;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.ServiceManagement.Queries
{
    public record GetAllRequestsQuery() : IRequest<APIResponse<List<BookingResponse>>>;

    public class GetAllRequestsQueryHandler : IRequestHandler<GetAllRequestsQuery, APIResponse<List<BookingResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public GetAllRequestsQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<APIResponse<List<BookingResponse>>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bookings = await _db.ServiceBookings
                    .Where(x => x.DeletedFlag == 'N')
                    .ToListAsync();

                var bookingResponses = new List<BookingResponse>();

                foreach (var booking in bookings)
                {
                    var service = await _db.Services.FindAsync(booking.ServiceId);
                    var serviceProvider = await _db.ServiceProviders.FindAsync(booking.ServiceProviderId);
                    var region = await _db.Regions.FindAsync(booking.RegionId);

                    var serviceName = service?.ServiceName ?? "Unknown Service"; ;
                    var regionName = region?.RegionName ?? "Unknown Region"; ;
                    var serviceProviderName = serviceProvider?.Name ?? "Unknown ServiceProvider"; ;


                    var bookingResponse = new BookingResponse
                    {
                        ServiceName = serviceName,
                        RegionName = regionName,
                        ServiceProviderName = serviceProviderName,
                        ProviderPhoneNumber = booking.ProviderPhoneNumber,
                        ProviderAccountNumber = booking.ProviderAccountNumber,
                        ProviderEmail = booking.ProviderEmail,
                        ServiceDate = booking.ServiceDate,
                        Comments = booking.Comments,
                        Status = booking.Status,
                        RequestId = booking.Id,
                        DeletedFlag = booking.DeletedFlag
                    };
                    bookingResponses.Add(bookingResponse);
                }
                return new APIResponse<List<BookingResponse>>
                {
                    Message = "Requests retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = bookingResponses,
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<List<BookingResponse>>
                {
                    Message = "Error occurred while retrieving requests",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

    }
}