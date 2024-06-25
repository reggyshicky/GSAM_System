using Application.ClaimManagement.InternalClaim.Dto;
using Application.Common;
using Application.Models;
using AutoMapper;
using Azure.Core;
using Domain.Entities.ClaimMngt;
using Infrastructure.Data;
using MediatR;
using System.Net;

namespace Application.ClaimManagement.InternalClaim.Commands
{
    public record AddInternalCommand(string StaffPF,
                                     string StaffName,
                                     string AccountNumber,
                                     decimal ClaimAmount,
                                     string EmailAddress,
                                     string ClaimRequestDeatails) : IRequest<APIResponse<InternalResponseDto>>;
    public sealed class AddInternalCommandHandler : IRequestHandler<AddInternalCommand, APIResponse<InternalResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public AddInternalCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;

        }
        public async Task<APIResponse<InternalResponseDto>> Handle(AddInternalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var obj = _mapper.Map<Internal>(request);
                obj.CreatedFlag = 'Y';
                obj.CreatedTime = DateTime.Now;
                obj.CreatedBy = _user.GetCurrentUserName();
                await _db.Internals.AddAsync(obj);
                await _db.SaveChangesAsync();
                return new APIResponse<InternalResponseDto>
                {
                    Message = $"Claim created succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<InternalResponseDto>(obj)

                };

            }
            catch
            {
                return new APIResponse<InternalResponseDto>
                {
                    Message = $"Error occurred while creating claim",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
