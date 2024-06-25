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
    public record GetUnApprovedRefinancedCasesQuery : IRequest<APIResponse<List<RefinanceDto>>>;

    public sealed class GetUnApprovedRefinancedCasesQueryHandler : IRequestHandler<GetUnApprovedRefinancedCasesQuery, APIResponse<List<RefinanceDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUnApprovedRefinancedCasesQueryHandler> _logger;
        public GetUnApprovedRefinancedCasesQueryHandler(ApplicationDbContext db, IMapper mapper, ILogger<GetUnApprovedRefinancedCasesQueryHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<APIResponse<List<RefinanceDto>>> Handle(GetUnApprovedRefinancedCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Refinances.Where(u => u.DeletedFlag == 'N' && u.VerifiedFlag == 'N').ToListAsync(cancellationToken);
            try
            {
                return new APIResponse<List<RefinanceDto>>
                {
                    Message = $"{results.Count} UnApproved Refinanced cases retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<RefinanceDto>>(results)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catched error {ex}");
                return new APIResponse<List<RefinanceDto>>
                {
                    Message = $"Error occurred while retrieving UnApproved Refinanced cases",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }

        }
    }
}
