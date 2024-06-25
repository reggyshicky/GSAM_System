using Application.CaseManagement.Dto;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.CaseManagement.Queries
{
    public record GetAssignedCasesQuery : IRequest<APIResponse<List<CaseResponseDto>>>;

    public sealed class GetAssignedCasesQueryHandler : IRequestHandler<GetAssignedCasesQuery, APIResponse<List<CaseResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetAssignedCasesQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<APIResponse<List<CaseResponseDto>>> Handle(GetAssignedCasesQuery request, CancellationToken cancellationToken)
        {
            var results = await _db.Cases.Where(u => u.DeletedFlag == 'N' && u.Assigned == 'Y').ToListAsync(cancellationToken);
            return new APIResponse<List<CaseResponseDto>>
            {
                Message = $"{results.Count} assigned were retrieved successfully!",
                StatusCode = HttpStatusCode.OK,
                Result = _mapper.Map<List<CaseResponseDto>>(results)
            };
        }
    }
}
