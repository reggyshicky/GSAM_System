using Application.CaseManagement.Dto;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Queries
{
    public record GetByCifQuery(string Cif) : IRequest<APIResponse<CaseResponseDto>>;

    public sealed class GetByCifQueryHandler : IRequestHandler<GetByCifQuery, APIResponse<CaseResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetByCifQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task<APIResponse<CaseResponseDto>> Handle(GetByCifQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Cases.FirstOrDefaultAsync(u => u.CifId == request.Cif && u.DeletedFlag == 'N', cancellationToken);
            if (results == null)
            {
                return new APIResponse<CaseResponseDto>
                {
                    Message = $"Case with number {request.Cif} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            return new APIResponse<CaseResponseDto>
            {
                Message = $"Case {results.CaseNumber} retrieved succesfully!",
                StatusCode = HttpStatusCode.OK,
                Result = _mapper.Map<CaseResponseDto>(results)

            };

        }
    }
}
