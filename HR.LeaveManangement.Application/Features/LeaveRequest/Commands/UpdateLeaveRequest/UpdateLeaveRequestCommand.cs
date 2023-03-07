using HR.LeaveManangement.Application.Features.LeaveRequest.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommand : BaseLeaveRequest , IRequest<Unit>
    {
        public int Id { get; set; } 

        public string RequestComments { get; set; } = String.Empty;

        public bool Cancelled { get; set; } 
    }
}
