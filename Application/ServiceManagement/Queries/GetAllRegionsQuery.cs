using Application.Models;
using Application.ServiceManagement.Dto;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.ServiceManagement.Queries
{
    public record GetAllRegionsQuery() : IRequest<APIResponse<List<RegionResponseDto>>>;

    public class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, APIResponse<List<RegionResponseDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public GetAllRegionsQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<APIResponse<List<RegionResponseDto>>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var regions = await _db.Regions
                    .Where(x => x.DeletedFlag == 'N')
                    .ToListAsync();

                return new APIResponse<List<RegionResponseDto>>
                {
                    Message = "Services retrieved succesfully!",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<RegionResponseDto>>(regions)
                };

            }
            catch (Exception ex)
            {
                return new APIResponse<List<RegionResponseDto>>
                {
                    Message = "Error occurred while retrieving succesfully!",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
