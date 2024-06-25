using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.ServiceMngt;
using Infrastructure.Data;
using MediatR;
using System.Net;


namespace Application.ServiceManagement.Commands
{
    public record AddRegionCommand(string RegionName) : IRequest<APIResponse<Unit>>;

    public sealed class AddRegionComamandHandler : IRequestHandler<AddRegionCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public AddRegionComamandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(AddRegionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var domainModel = _mapper.Map<Region>(request);
                domainModel.CreatedBy = _user.GetCurrentUserName();
                domainModel.CreatedFlag = 'Y';
                domainModel.CreatedTime = DateTime.Now;
                await _db.Regions.AddAsync(domainModel, cancellationToken);
                await _db.SaveChangesAsync();

                return new APIResponse<Unit>
                {
                    Message = "Region added succesfully!",
                    StatusCode = HttpStatusCode.Created
                };

            }
            catch (Exception ex)
            {
                return new APIResponse<Unit>
                {
                    Message = "Error occurred while adding the Region",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }


        }
    }
}
