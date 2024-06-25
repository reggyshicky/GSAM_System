using Application.ClaimManagement.ExternalClaim.Dto;
using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.ClaimMngt;
using Infrastructure.Data;
using MediatR;
using System.Net;

namespace Application.ClaimManagement.ExternalClaim.Commands
{
    public record AddExternalCommand(string ServiceName,
                                     string ServiceProvider,
                                     string AccountNumber,
                                     decimal ClaimAmount,
                                     string EmailAddress,
                                     DateTime ServiceDate,
                                     string ClaimRequestDetails):IRequest<APIResponse<ExternalResponseDto>>;
    public sealed class AddExternalCommandHandler : IRequestHandler<AddExternalCommand, APIResponse<ExternalResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        private readonly ApplicationDbContext _db;
        public AddExternalCommandHandler(IMapper mapper, ICurrentUser user, ApplicationDbContext db)
        {
            _mapper = mapper;
            _user = user;
            _db = db;
        }
        public async Task<APIResponse<ExternalResponseDto>> Handle(AddExternalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var external = _mapper.Map<External>(request);
                external.CreatedFlag = 'Y';
                external.CreatedBy = _user.GetCurrentUserName();
                external.CreatedTime = DateTime.Now;
                await _db.Externals.AddAsync(external);
                await _db.SaveChangesAsync();


                return new APIResponse<ExternalResponseDto>
                {
                    Message = $"Claim added successfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<ExternalResponseDto>(external)


                };
            }
            catch
            {
                return new APIResponse<ExternalResponseDto>
                {
                    Message = $"Error occured while creating Claim",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
            
        }
    }
}
