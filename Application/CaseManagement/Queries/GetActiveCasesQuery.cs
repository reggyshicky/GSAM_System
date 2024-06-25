using Application.CaseManagement.Dto;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Queries
{
    public record GetActiveCasesQuery : IRequest<APIResponse<List<CaseResponseDto>>>;

    public sealed class GetActiveCasesQueryHandler : IRequestHandler<GetActiveCasesQuery, APIResponse<List<CaseResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetActiveCasesQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<APIResponse<List<CaseResponseDto>>> Handle(GetActiveCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Cases.Where(u => u.DeletedFlag == 'N' && u.Status == "Active").ToListAsync(cancellationToken);

            return new APIResponse<List<CaseResponseDto>>
            {
                Message = $"{results.Count} active cases retrieved successfully!",
                StatusCode = HttpStatusCode.OK,
                Result = _mapper.Map<List<CaseResponseDto>>(results)

            };
        }
    }
}
