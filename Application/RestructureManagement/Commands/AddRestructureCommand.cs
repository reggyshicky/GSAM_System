using Application.Common;
using Application.Models;
using AutoMapper;
using Domain.Entities.RestructureMgnt;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.RestructureManagement.Commands
{
    public record AddRestructureCommand(string CifID,
                                        string AccountName,
                                        string LoanAccount,
                                        int CaseNumber,
                                        string Comments,
                                        string SolId,
                                        decimal LoanBalance,
                                        decimal InitialInstalments,
                                        decimal NewInstalments,
                                        int LoanTenure,
                                        int NewLoanTenure) : IRequest<APIResponse<Unit>>;

    public sealed class AddRestructureCommandHandler : IRequestHandler<AddRestructureCommand, APIResponse<Unit>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _user;

        public AddRestructureCommandHandler(ApplicationDbContext db, IMapper mapper, ICurrentUser user)
        {
            _db = db;
            _mapper = mapper;
            _user = user;
        }
        public async Task<APIResponse<Unit>> Handle(AddRestructureCommand request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<Restructure>(request);
            obj.RestructuredBy = _user.GetCurrentUserName();
            obj.RestructuredFlag = 'Y';
            obj.RestructuredTime = DateTime.Now;
            await _db.AddAsync(obj);

            //update the case table
            var caseRecord = await _db.Cases.FirstOrDefaultAsync(x => x.CaseNumber == request.CaseNumber);
            if (caseRecord == null)
            {
                return new APIResponse<Unit>
                {
                    Message = "Case not found. We need to update also on the Case Table",
                    StatusCode = HttpStatusCode.NotFound,
                };
            }
            caseRecord.RestructuredFlag = 'Y';
            await _db.SaveChangesAsync();

            return new APIResponse<Unit>
            {
                Message = "Case Restructured succesfully!",
                StatusCode = HttpStatusCode.Created,
                Result = Unit.Value
            };
        }
    }
}

