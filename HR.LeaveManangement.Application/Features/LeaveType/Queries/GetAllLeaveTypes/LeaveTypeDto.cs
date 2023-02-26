using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class LeaveTypeDto
    {
        public int Int { get; set; }
        public string Name { get; set; } = String.Empty;
        public int DefaultDays { get; set; }
    }
}
