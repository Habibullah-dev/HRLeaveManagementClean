using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManangement.Application.contracts.persistence;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {
      

    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);

        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
        var leaveRequests = await _context.LeaveRequests
                                    .Include(q => q.LeaveType)
                                     .ToListAsync();   

        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
    {
        var leaveRequests = await _context.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
                            .Include(q => q.LeaveType)           
                            .ToListAsync();
        return leaveRequests;
    }
}


