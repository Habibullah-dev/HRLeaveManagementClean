using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

//public class GetLeaveTypes : IRequest<List<LeaveTypeDto>>{}

public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>{}
