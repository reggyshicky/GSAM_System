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

    public record GetAllDocumentsQuery : IRequest<APIResponse<List<DocumentResponseDto>>>;
    public sealed class GetAllDocumentsQueryHandler : IRequestHandler<GetAllDocumentsQuery, APIResponse<List<DocumentResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetAllDocumentsQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<APIResponse<List<DocumentResponseDto>>> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _db.Documents.ToListAsync(cancellationToken);
            var documentDtos = _mapper.Map<List<DocumentResponseDto>>(documents);

            return new APIResponse<List<DocumentResponseDto>>
            {
                Message = "Documents retrieved successfully!",
                StatusCode = HttpStatusCode.OK,
                Result = documentDtos
            };
        }
    }
}
