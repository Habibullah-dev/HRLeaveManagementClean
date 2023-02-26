using HR.LeaveManagement.Domain;

namespace HR.LeaveManangement.Application.contracts.persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> IsLeaveTypeUnique(string name);
}
