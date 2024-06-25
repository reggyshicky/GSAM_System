using Application.Models;
using Application.ServiceManagement.Dto;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.ServiceManagement.Queries
{
    public record GetAllServiceProviderQuery() : IRequest<APIResponse<List<ServiceProviderResponseDto>>>;

    public class GetAllServiceProviderQueryHandler : IRequestHandler<GetAllServiceProviderQuery, APIResponse<List<ServiceProviderResponseDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public GetAllServiceProviderQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<APIResponse<List<ServiceProviderResponseDto>>> Handle(GetAllServiceProviderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var services = await _db.ServiceProviders
                    .Where(x => x.DeletedFlag == 'N')
                    .Include(x => x.Service)
                    .Include(x => x.Region)
                    .ToListAsync();

                return new APIResponse<List<ServiceProviderResponseDto>>
                {
                    Message = "Service Providers retrieved succesfully!",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<ServiceProviderResponseDto>>(services)
                };

            }
            catch (Exception ex)
            {
                return new APIResponse<List<ServiceProviderResponseDto>>
                {
                    Message = "Error occurred while retrieving service providers!",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
