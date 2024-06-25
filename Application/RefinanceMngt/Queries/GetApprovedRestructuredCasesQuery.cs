using Application.Models;
using Application.RefinanceMngt.Dto;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.RestructureManagement.Queries
{
    public record GetApprovedRefinancedCasesQuery : IRequest<APIResponse<List<RefinanceDto>>>;

    public sealed class GetApprovedRefinancedCasesQueryHandler : IRequestHandler<GetApprovedRefinancedCasesQuery, APIResponse<List<RefinanceDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GetApprovedRefinancedCasesQueryHandler> _logger;
        public GetApprovedRefinancedCasesQueryHandler(ApplicationDbContext db, IMapper mapper, ILogger<GetApprovedRefinancedCasesQueryHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<APIResponse<List<RefinanceDto>>> Handle(GetApprovedRefinancedCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Refinances.Where(u => u.DeletedFlag == 'N' && u.VerifiedFlag == 'Y').ToListAsync(cancellationToken);
            try
            {
                return new APIResponse<List<RefinanceDto>>
                {
                    Message = $"{results.Count} Approved Refinanced cases retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<RefinanceDto>>(results)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catched error {ex}");
                return new APIResponse<List<RefinanceDto>>
                {
                    Message = $"Error occurred while retrieving Approved Refinanced cases",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
