using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManangement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManangement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();

        CreateMap<LeaveType, LeaveTypeDetailsDto>();

        CreateMap<CreateLeaveTypeCommand, LeaveType>();

        CreateMap<UpdateLeaveTypeCommand, LeaveType>();

    }

}
