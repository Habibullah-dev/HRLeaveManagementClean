﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest
{
    public class GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>
    {

    }
}
