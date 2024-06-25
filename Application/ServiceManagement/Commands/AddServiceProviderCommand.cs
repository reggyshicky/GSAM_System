using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.ServiceMngt;
using Infrastructure.Data;
using MediatR;
using System.Net;


namespace Application.ServiceManagement.Commands
{
    public record AddServiceProviderCommand(string Name,
                                             string AccountNumber,
                                             string PhoneNumber,
                                             string? Postal,
                                             string Email,
                                             int ServiceId,
                                             int RegionId) : IRequest<APIResponse<Unit>>;

    public sealed class AddServiceProviderComamandHandler : IRequestHandler<AddServiceProviderCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public AddServiceProviderComamandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(AddServiceProviderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var domainModel = _mapper.Map<ServiceProvider>(request);
                domainModel.CreatedBy =/* _user.GetCurrentUserName();*/ "Reginah";
                domainModel.CreatedFlag = 'Y';
                domainModel.CreatedTime = DateTime.Now;
                await _db.ServiceProviders.AddAsync(domainModel, cancellationToken);
                await _db.SaveChangesAsync();

                return new APIResponse<Unit>
                {
                    Message = "Service Provider added succesfully!",
                    StatusCode = HttpStatusCode.Created
                };

            }
            catch (Exception ex)
            {
                return new APIResponse<Unit>
                {
                    Message = "Error occurred while adding the service",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }


        }
    }
}
