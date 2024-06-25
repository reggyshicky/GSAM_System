using Application.Models;
using Application.ServiceManagement.Dto;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.ServiceManagement.Queries
{
    public record GetAllServicesQuery() : IRequest<APIResponse<List<ServiceResponseDto>>>;

    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, APIResponse<List<ServiceResponseDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public GetAllServicesQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<APIResponse<List<ServiceResponseDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var services = await _db.Services
                    .Where(x => x.DeletedFlag == 'N')
                    .ToListAsync();

                return new APIResponse<List<ServiceResponseDto>>
                {
                    Message = "Services retrieved succesfully!",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<ServiceResponseDto>>(services)
                };

            }
            catch (Exception ex)
            {
                return new APIResponse<List<ServiceResponseDto>>
                {
                    Message = "Error occurred while retrieving service providers!",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
