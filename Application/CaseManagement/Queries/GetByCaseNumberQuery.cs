using Application.CaseManagement.Dto;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Queries
{
    public record GetByCaseNumberQuery(int CaseNumber) : IRequest<APIResponse<CaseResponseDto>>;

    public sealed class GetByCaseNumberQueryHandler : IRequestHandler<GetByCaseNumberQuery, APIResponse<CaseResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetByCaseNumberQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<APIResponse<CaseResponseDto>> Handle(GetByCaseNumberQuery request, CancellationToken cancellationToken)
        {
            var result = await _db.Cases.FirstOrDefaultAsync(u => u.CaseNumber == request.CaseNumber && u.DeletedFlag == 'N', cancellationToken);
            if (result == null)
            {
                return new APIResponse<CaseResponseDto>
                {
                    Message = $"Case with number {request.CaseNumber} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            return new APIResponse<CaseResponseDto>
            {
                Result = _mapper.Map<CaseResponseDto>(result),
                Message = $"Case {result.CaseNumber} retrieved succesfully",
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
