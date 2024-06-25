

using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Application.ClaimManagement.InternalClaim.Dto;


namespace Application.ClaimManagement.InternalClaim.Queries
{
    public record GetInternalClaimsQuery() : IRequest<APIResponse<List<InternalResponseDto>>>;

    public sealed class GetInternalClaimsQueryHandler : IRequestHandler<GetInternalClaimsQuery, APIResponse<List<InternalResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetInternalClaimsQueryHandler(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<APIResponse<List<InternalResponseDto>>> Handle(GetInternalClaimsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var results = await _db.Internals.Where(x => x.DeletedFlag == 'N').ToListAsync();
                return new APIResponse<List<InternalResponseDto>>
                {
                    Message = $"Created claims Retrieved succesfullly",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<InternalResponseDto>>(results)

                };
            }
            catch
            {
                return new APIResponse<List<InternalResponseDto>>
                {
                    Message = $"Error occurred while retrieving created claims",
                    StatusCode = HttpStatusCode.OK,
                };
            }

        }



    }
}
