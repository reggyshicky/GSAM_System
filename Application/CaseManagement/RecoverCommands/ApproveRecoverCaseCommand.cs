using Application.CaseManagement.Dto.RecoverDtos;
using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CaseManagement.RecoverCommands
{
    public sealed class ApproveRecoverCaseCommand : IRequest<APIResponse<RecoverResponseDto>>;
    
    
}
