using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.CreateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto,LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
