using Application.Common;
using Application.Models;
using Application.RefinanceMngt.Dto;
using AutoMapper;
using Domain.Entities.RefinanceMngt;
using Infrastructure.Data;
using MediatR;
using System.Net;

namespace Application.RefinanceMngt.Commands
{
    public record AddRefinanceCommand (string CifID,
                                       string LoanAccount,
                                       int CaseNumber,
                                       decimal LoanAmount,
                                       decimal RefinanceAmount,
                                       string SolId,
                                       decimal InitialInstalments,
                                       int NewLoanTenure,
                                       string AccountName,
                                       int LoanTenure,
                                       decimal LoanBalance,
                                       string Comments,
                                       decimal NewInstalments) : IRequest<APIResponse<RefinanceDto>>;

    public sealed class AddRefinanceCommandHandler : IRequestHandler<AddRefinanceCommand, APIResponse<RefinanceDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;
        public AddRefinanceCommandHandler(IMapper mapper, ApplicationDbContext db, ICurrentUser user)
        {
            _mapper = mapper;
            _db = db;
            _user = user;
        }
        public async Task<APIResponse<RefinanceDto>> Handle(AddRefinanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var refinance = _mapper.Map<Refinance>(request);
                refinance.RefinancedFlag = 'Y';
                refinance.RefinancedTime = DateTime.Now;
                refinance.RefinancedBy = _user.GetCurrentUserName();
                await _db.Refinances.AddAsync(refinance);
                await _db.SaveChangesAsync();
                return new APIResponse<RefinanceDto>
                {
                    Message = $"Case Number {request.CaseNumber} refinanced succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<RefinanceDto>(refinance)

                };

            }
            catch
            {
                return new APIResponse<RefinanceDto>
                {
                    Message = $"Error occurred while refinancing case number {request.CaseNumber}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
