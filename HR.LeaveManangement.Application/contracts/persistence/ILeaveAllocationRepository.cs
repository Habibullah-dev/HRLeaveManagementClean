using HR.LeaveManagement.Domain;

namespace HR.LeaveManangement.Application.contracts.persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);

    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();

    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userid);

    Task<bool> AllocationExists(string userId, int leaveTypeId, int period);

    Task AddAllocations(List<LeaveAllocation> allocations);

    Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId);



}
