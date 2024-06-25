using Application.Common;
using Application.Models;
using Domain.Entities.ServiceMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Application.ServiceManagement.Commands
{
    public record BookingDocumentCommand(int ServiceBookingId,
                                          string FileName,
                                          string Folder,
                                          IFormFile File) : IRequest<APIResponse<object>>;

    public sealed class BookingDocumentCommandHandler : IRequestHandler<BookingDocumentCommand, APIResponse<object>>
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _user;
        private readonly string _basePath;
        public BookingDocumentCommandHandler(ApplicationDbContext db, ICurrentUser user, IConfiguration configuration)
        {
            _db = db;
            _user = user;
            _basePath = configuration["BookingDocumentBasePath"];
        }
        public async Task<APIResponse<object>> Handle(BookingDocumentCommand request, CancellationToken cancellationToken)
        {
            var fileDirectory = GetDirectoryPath(request.Folder);
            var filePath = Path.Combine(fileDirectory, request.FileName);

            var documents = new BookingDocument
            {
                ServiceBookingId = request.ServiceBookingId,
                FileName = request.FileName,
                Folder = request.Folder,
                FilePath = filePath,
                UploadedBy = _user.GetCurrentUserName(),
                UploadedTime = DateTime.Now,
                UploadedFlag = 'Y'
            };

            Directory.CreateDirectory(fileDirectory);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await request.File.CopyToAsync(stream, cancellationToken);

            await _db.BookingDocuments.AddAsync(documents, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            var documentUrl = Path.Combine(_basePath, documents.FilePath);
            return new APIResponse<object>
            {
                Message = "Booking Document uploaded successfully!",
                StatusCode = HttpStatusCode.Created,
                Result = new { DocumentUrl = documentUrl },
            };
        }

        public string GetDirectoryPath(string folder)
        {
            return Path.Combine(_basePath, folder);
        }
    }
}
