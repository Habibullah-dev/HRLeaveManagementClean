using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.contracts.persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {

    }
}
