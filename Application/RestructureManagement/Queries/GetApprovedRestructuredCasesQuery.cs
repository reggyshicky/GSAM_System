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
    public record GetApprovedRestructuredCasesQuery : IRequest<APIResponse<List<RestructureResponseDto>>>;

    public sealed class GetApprovedRestructuredCasesQueryHandler : IRequestHandler<GetApprovedRestructuredCasesQuery, APIResponse<List<RestructureResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GetApprovedRestructuredCasesQueryHandler> _logger;
        public GetApprovedRestructuredCasesQueryHandler(ApplicationDbContext db, IMapper mapper, ILogger<GetApprovedRestructuredCasesQueryHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<APIResponse<List<RestructureResponseDto>>> Handle(GetApprovedRestructuredCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Restructures.Where(u => u.DeletedFlag == 'N' && u.VerifiedFlag == 'Y').ToListAsync(cancellationToken);
            try
            {
                return new APIResponse<List<RestructureResponseDto>>
                {
                    Message = $"{results.Count} Approved Restructured cases retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<RestructureResponseDto>>(results)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catched error {ex}");
                return new APIResponse<List<RestructureResponseDto>>
                {
                    Message = $"Error occurred while retrieving Approved Restructured cases",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }

        }
    }
}
