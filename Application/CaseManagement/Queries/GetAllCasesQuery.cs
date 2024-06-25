using Application.CaseManagement.Dto;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace Application.CaseManagement.Queries
{
    public record GetAllCasesQuery : IRequest<APIResponse<List<CaseResponseDto>>>;

    public sealed class GetAllCasesQueryHandler : IRequestHandler<GetAllCasesQuery, APIResponse<List<CaseResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetAllCasesQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<APIResponse<List<CaseResponseDto>>> Handle(GetAllCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Cases.Where(u => u.DeletedFlag == 'N').ToListAsync(cancellationToken);
            return new APIResponse<List<CaseResponseDto>>
            {
                Message = $"{results.Count} retrieved succesfully",
                StatusCode = HttpStatusCode.OK,
                Result = _mapper.Map<List<CaseResponseDto>>(results)
            };
        }
    }
}
