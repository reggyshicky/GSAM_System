using Application.Models;
using Application.RestructureManagement.Dtos;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.RestructureManagement.Queries
{
    public record GetUnApprovedRestructuredCasesQuery : IRequest<APIResponse<List<RestructureResponseDto>>>;

    public sealed class GetUnApprovedRestructuredCasesQueryHandler : IRequestHandler<GetUnApprovedRestructuredCasesQuery, APIResponse<List<RestructureResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUnApprovedRestructuredCasesQueryHandler> _logger;
        public GetUnApprovedRestructuredCasesQueryHandler(ApplicationDbContext db, IMapper mapper, ILogger<GetUnApprovedRestructuredCasesQueryHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<APIResponse<List<RestructureResponseDto>>> Handle(GetUnApprovedRestructuredCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Restructures.Where(u => u.DeletedFlag == 'N' && u.VerifiedFlag == 'N').ToListAsync(cancellationToken);
            try
            {
                return new APIResponse<List<RestructureResponseDto>>
                {
                    Message = $"{results.Count} UnApproved Restructured cases retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<RestructureResponseDto>>(results)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catched error {ex}");
                return new APIResponse<List<RestructureResponseDto>>
                {
                    Message = $"Error occurred while retrieving UnApproved Restructured cases",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }

        }
    }
}
