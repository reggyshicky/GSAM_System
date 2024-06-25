using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.DocumentMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Linq;
using Application.FileManagement.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Application.DocumentManagement.Queries
{

    public record GetDocumentByIdQuery(int Id) : IRequest<APIResponse<List<DocumentResponseDto>>>;
    public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, APIResponse<List<DocumentResponseDto>>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly string _basePath;

        public GetDocumentByIdQueryHandler(ApplicationDbContext db, IMapper mapper, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _basePath = configuration["DocumentBasePath"];
        }

        public async Task<APIResponse<List<DocumentResponseDto>>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var documents = await _db.Documents
                                      .Where(d => d.Id == request.Id)
                                      .ToListAsync(cancellationToken);

            if (!documents.Any())
            {
                return new APIResponse<List<DocumentResponseDto>>
                {
                    Message = "No documents found with the specified Id.",
                    StatusCode = HttpStatusCode.NotFound,
                    Result = null
                };
            }

            var documentDtos = _mapper.Map<List<DocumentResponseDto>>(documents);
            foreach (var documentDto in documentDtos)
            {
                // documentDto.DocumentUrl = Path.Combine(_basePath, "DocumentServices", documentDto.FilePath);
            }

            return new APIResponse<List<DocumentResponseDto>>
            {
                Message = "Documents retrieved successfully!",
                StatusCode = HttpStatusCode.OK,
                Result = documentDtos
            };
        }
    }
}
