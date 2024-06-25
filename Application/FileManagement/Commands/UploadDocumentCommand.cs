using Application.Common;
using Application.Models;
using Domain.Entities.DocumentMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Application.DocumentManagement.Commands
{
    public record UploadDocumentCommand(string FileName,
                                        string AccountName,
                                        string Folder,
                                     string FileType,
                                     string FileExtension,
                                     string LoanAccount,
                                     IFormFile File) : IRequest<APIResponse<object>>;

    public sealed class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, APIResponse<object>>
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _user;
        private readonly string _basePath;

        public UploadDocumentCommandHandler(ApplicationDbContext db, ICurrentUser user, IConfiguration configuration)
        {
            _db = db;
            _user = user;
            _basePath = configuration["DocumentBasePath"];
        }

        public async Task<APIResponse<object>> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
        {
            var fileDirectory = GetDirectoryPath(request.Folder); // Use the Folder field
            var filePath = Path.Combine(fileDirectory, request.FileName);

            var document = new Documents
            {
                FileName = request.FileName,
                AccountName = request.AccountName,
                Folder = request.Folder, // Ensure Folder is saved correctly
                FileType = request.FileType,
                FileExtension = request.FileExtension,
                FilePath = filePath,
                LoanAccount = request.LoanAccount,
                UploadedBy = _user.GetCurrentUserName(),
                UploadedTime = DateTime.Now,
                VerifiedFlag='N',
                CreatedOn = DateTime.Now
            };

            Directory.CreateDirectory(fileDirectory);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await request.File.CopyToAsync(stream, cancellationToken);

            await _db.Documents.AddAsync(document, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            var documentUrl = Path.Combine(_basePath, "DocumentServices", document.FilePath);

            return new APIResponse<object>
            {
                Message = "Document uploaded successfully!",
                StatusCode = HttpStatusCode.Created,
                Result = new { DocumentUrl = documentUrl },
            };
        }

        private string GetDirectoryPath(string folder)
        {
            return Path.Combine(_basePath, "DocumentServices", folder);
        }
    }
}

