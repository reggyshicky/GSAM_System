using Application.FileManagement.Dtos;
using Application.Models;
using AutoMapper;
using Domain.Entities.DocumentMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DocumentManagement.Queries
{
    public record GetUnApprovedDocumentsQuery : IRequest<APIResponse<List<DocumentResponseDto>>>;

    public sealed class GetUnApprovedDocumentsQueryHandler : IRequestHandler<GetUnApprovedDocumentsQuery, APIResponse<List<DocumentResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetUnApprovedDocumentsQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<APIResponse<List<DocumentResponseDto>>> Handle(GetUnApprovedDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _db.Documents
                                     .Where(doc => doc.VerifiedFlag == 'N' && doc.DeletedFlag == 'N')
                                     .ToListAsync(cancellationToken);

            var documentDtos = _mapper.Map<List<DocumentResponseDto>>(documents);

            return new APIResponse<List<DocumentResponseDto>>
            {
                Message = "Unapproved documents retrieved successfully!",
                StatusCode = HttpStatusCode.OK,
                Result = documentDtos
            };
        }
    }
}
