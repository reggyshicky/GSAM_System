using Application.CaseManagement.Dto;
using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.CaseMgnt;
using Infrastructure.Data;
using MediatR;
using System.Net;

namespace Application.CaseManagement.Commands
{
    public sealed record AddCaseCommand(string CifId,
                                        string AccountName,
                                        decimal LoanAmount,
                                        int LoanTenure,
                                        string SolId,
                                        decimal LoanBalance,
                                        string LoanAccount,
                                        char SyndicatedFlag) : IRequest<APIResponse<CaseResponseDto>>;

    public sealed class AddCaseCommandHandler : IRequestHandler<AddCaseCommand, APIResponse<CaseResponseDto>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public AddCaseCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }

        public async Task<APIResponse<CaseResponseDto>> Handle(AddCaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var thecase = _mapper.Map<Case>(request);
                thecase.CreatedBy = _user.GetCurrentUserName();
                thecase.Status = "Active";
                thecase.CreatedFlag = 'Y';
                thecase.CreatedTime = DateTime.Now;
                await _db.Cases.AddAsync(thecase, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                return new APIResponse<CaseResponseDto>
                {
                    Result = _mapper.Map<CaseResponseDto>(thecase),
                    StatusCode = HttpStatusCode.Created,
                    Message = $"Case with case number {thecase.CaseNumber} has been created succesfully!"
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<CaseResponseDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = $"Case with loan account {request.LoanAccount} already exists!"
                };

            }
        }
    }
}
