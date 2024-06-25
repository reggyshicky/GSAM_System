using Application.CaseManagement.Dto.RecoverDtos;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Queries.RecoverCaseQueries
{
    public record GetAllRecoverCases : IRequest<APIResponse<List<RecoverResponseDto>>>;

    public sealed class GetAllRecoverCasesHandler : IRequestHandler<GetAllRecoverCases, APIResponse<List<RecoverResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetAllRecoverCasesHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<APIResponse<List<RecoverResponseDto>>> Handle(GetAllRecoverCases request, CancellationToken cancellationToken)
        {
            var results = await _db.Recovers.Where(u => u.DeletedFlag == 'N').ToListAsync(cancellationToken);
            return new APIResponse<List<RecoverResponseDto>>
            {
                Message = $"{results.Count} Recover cases retrieved succesfully!",
                StatusCode = HttpStatusCode.OK,
                Result = _mapper.Map<List<RecoverResponseDto>>(results)
            };
        }
    }
}