using Application.CaseManagement.Dto;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Queries
{
    public record GetUnApprovedCasesQuery : IRequest<APIResponse<List<CaseResponseDto>>>;

    public sealed class GetUnApprovedQueryHandler : IRequestHandler<GetUnApprovedCasesQuery, APIResponse<List<CaseResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetUnApprovedQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<APIResponse<List<CaseResponseDto>>> Handle(GetUnApprovedCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Cases.Where(u => u.DeletedFlag == 'N' && u.VerifiedFlag == 'N').ToListAsync(cancellationToken);
            return new APIResponse<List<CaseResponseDto>>
            {
                Message = $"{results.Count} Unapproved cases retrieved succesfully",
                StatusCode = HttpStatusCode.OK,
                Result = _mapper.Map<List<CaseResponseDto>>(results)
            };
        }
    }
}
