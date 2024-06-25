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
    public record GetAllRestructuredQuery : IRequest<APIResponse<List<RestructureResponseDto>>>;

    public sealed class GetAllRestructuredQueryHandler : IRequestHandler<GetAllRestructuredQuery, APIResponse<List<RestructureResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllRestructuredQueryHandler> _logger;
        public GetAllRestructuredQueryHandler(ApplicationDbContext db, IMapper mapper, ILogger<GetAllRestructuredQueryHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<APIResponse<List<RestructureResponseDto>>> Handle(GetAllRestructuredQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Restructures.Where(u => u.DeletedFlag == 'N').ToListAsync(cancellationToken);
            try
            {
                return new APIResponse<List<RestructureResponseDto>>
                {
                    Message = $"{results.Count} Restructured cases retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<RestructureResponseDto>>(results)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Catched error {ex}");
                return new APIResponse<List<RestructureResponseDto>>
                {
                    Message = $"Error occurred while retrieving Restructured cases",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }

        }
    }
}
