using Application.ClaimManagement.ExternalClaim.Dto;
using Application.Models;
using AutoMapper;
using Azure.Core;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Application.ClaimManagement.ExternalClaim.Queries
{
    public record class GetExternalClaimsQuery:IRequest<APIResponse<List<ExternalResponseDto>>>;
    
    public sealed class GetExternalQueryHandler : IRequestHandler<GetExternalClaimsQuery, APIResponse<List<ExternalResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GetExternalQueryHandler> _logger;

        public GetExternalQueryHandler(ApplicationDbContext db, IMapper mapper, ILogger<GetExternalQueryHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<APIResponse<List<ExternalResponseDto>>> Handle(GetExternalClaimsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var results = await _db.Externals.Where(x => x.DeletedFlag == 'N').ToListAsync();
                return new APIResponse<List<ExternalResponseDto>>
                {
                    Message = $"Claims Retrieved successfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<ExternalResponseDto>>(results)
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Caught error {ex}");
                return new APIResponse<List<ExternalResponseDto>>
                {
                    Message = $"Error occured while retrieving claims",
                    StatusCode = HttpStatusCode.InternalServerError
                };

            }

        }
    }
}

