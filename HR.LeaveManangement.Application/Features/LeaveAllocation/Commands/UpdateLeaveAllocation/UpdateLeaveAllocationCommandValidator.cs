using FluentValidation;
using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository) 
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._leaveAllocationRepository = leaveAllocationRepository;
            RuleFor(p => p.NumberOfDays)

                .GreaterThan(0).WithMessage("{PropertyName} Must be greater than {ComparisonValue}");

            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(LeaveTypeMustExist)
                .WithMessage("{PropertyName}  does not exist");

            RuleFor(p => p.Id).NotNull().MustAsync(LeaveAllocationMustExist).WithMessage("{PropertyName} must be present");

        }

        private async Task<bool> LeaveAllocationMustExist(int arg1, CancellationToken arg2)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(arg1);

            return leaveAllocation != null;
        }

        private async Task<bool>  LeaveTypeMustExist(int id, CancellationToken cancellation)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);

            return leaveType != null;
        }

    }
}
