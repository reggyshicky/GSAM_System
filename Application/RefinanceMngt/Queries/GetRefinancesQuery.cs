using Application.Models;
using Application.RefinanceMngt.Dto;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Application.RefinanceMngt.Queries
{
    public record GetRefinancesQuery() : IRequest<APIResponse<List<RefinanceDto>>>;

    public sealed class GetRefinancesQueryHandler : IRequestHandler<GetRefinancesQuery, APIResponse<List<RefinanceDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetRefinancesQueryHandler(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<APIResponse<List<RefinanceDto>>> Handle(GetRefinancesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var results = await _db.Refinances.Where(x => x.DeletedFlag == 'N').ToListAsync();
                return new APIResponse<List<RefinanceDto>>
                {
                    Message = $"Refinanced Cases Retrieved succesfullly",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<RefinanceDto>>(results)

                };
            }
            catch
            {
                return new APIResponse<List<RefinanceDto>>
                {
                    Message = $"Error occurred while retrieving Refinanced cases",
                    StatusCode = HttpStatusCode.OK,
                };
            }

        }
    }
}
