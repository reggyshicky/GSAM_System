using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.ServiceMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Net;
using System.Web.Mvc;


namespace Application.ServiceManagement.Commands
{
    public record AddServiceCommand(string ServiceName) : IRequest<APIResponse<Unit>>;

    public sealed class AddServiceComamandHandler : IRequestHandler<AddServiceCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public AddServiceComamandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(AddServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var domainModel = _mapper.Map<Service>(request);
                domainModel.CreatedBy = _user.GetCurrentUserName();;
                domainModel.CreatedFlag = 'Y';
                domainModel.CreatedTime = DateTime.Now;
                await _db.Services.AddAsync(domainModel, cancellationToken);
                await _db.SaveChangesAsync();

                return new APIResponse<Unit>
                {
                    Message = "Service added succesfully!",
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
