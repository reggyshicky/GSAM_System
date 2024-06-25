using Application.CaseManagement.Dto;
using Application.Common;
using Application.CsseManagement.Dtos;
using Application.Models;
using AutoMapper;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.Commands
{
    public record UpdateCaseCommand(int CaseNumber, JsonPatchDocument<UpdateDto> PatchDocument) : IRequest<APIResponse<CaseResponseDto>>;


    public sealed class UpdateCaseCommandHandler : IRequestHandler<UpdateCaseCommand, APIResponse<CaseResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public UpdateCaseCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<CaseResponseDto>> Handle(UpdateCaseCommand request, CancellationToken cancellationToken)
        {
            var thecase = await _db.Cases.AsNoTracking().FirstOrDefaultAsync(u => u.CaseNumber == request.CaseNumber);

            if (thecase == null)
            {
                return new APIResponse<CaseResponseDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Case with number {request.CaseNumber} not found"
                };
            }
            //Map the existing case to an update DTO
            var updateDto = _mapper.Map<UpdateDto>(thecase);

            //Apply the patch document to the update DTO
            request.PatchDocument.ApplyTo(updateDto);

            //Map the updated properties from the DTO back to the existing case entity
            _mapper.Map(updateDto, thecase);

            thecase.ModifiedBy = _user.GetCurrentUserName();
            thecase.ModifiedFlag = 'Y';
            thecase.ModifiedTime = DateTime.Now;
            thecase.VerifiedFlag = 'N';
            _db.Cases.Update(thecase);
            await _db.SaveChangesAsync();
            return new APIResponse<CaseResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = $"Case {request.CaseNumber} updated succesfully",
                Result = _mapper.Map<CaseResponseDto>(thecase)
            };
        }
    }
}
