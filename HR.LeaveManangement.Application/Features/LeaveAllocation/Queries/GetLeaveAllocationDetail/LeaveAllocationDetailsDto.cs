using HR.LeaveManangement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail
{
    public class LeaveAllocationDetailsDto
    {
        public int Id { get; set; }

        public int NumberOfDays { get; set; }

        public LeaveTypeDto leaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
