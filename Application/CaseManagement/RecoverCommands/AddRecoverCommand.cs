using Application.CaseManagement.Dto.RecoverDtos;
using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.RecoverMngt;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.CaseManagement.RecoverCommands
{
    public sealed record AddRecoverCommand(string CifId,
                                            string LoanAccount,
                                            int CaseNumber,
                                            string Comments,
                                            string AccountName,
                                            string SolId,
                                            decimal LoanAmount,
                                            decimal LoanPaid,
                                            decimal LoanBalance,
                                            int MonthsInDefault
                                            ) : IRequest<APIResponse<Unit>>;

    public sealed class AddRecoverCommandHandler : IRequestHandler<AddRecoverCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public AddRecoverCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }

        public async Task<APIResponse<Unit>> Handle(AddRecoverCommand request, CancellationToken cancellationToken)
        {
            var recoverCase = _mapper.Map<Recover>(request);
            recoverCase.RecoveredBy = _user.GetCurrentUserName();
            recoverCase.RecoveredTime = DateTime.Now;
            recoverCase.RecoveredFlag = 'Y';
            await _db.Recovers.AddAsync(recoverCase, cancellationToken);

            var caseEntity = await _db.Cases.FirstOrDefaultAsync(c => c.CaseNumber == request.CaseNumber, cancellationToken);
            if (caseEntity != null)
            {
                caseEntity.RecoveredFlag = 'Y';
                _db.Cases.Update(caseEntity);
            }

            await _db.SaveChangesAsync(cancellationToken);

            return new APIResponse<Unit>
            {
                Message = "Recover case added succesfully!",
                StatusCode = HttpStatusCode.Created,
                Result = Unit.Value
            };
        }
    }
}

