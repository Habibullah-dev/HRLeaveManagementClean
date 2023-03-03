using FluentValidation;
using HR.LeaveManangement.Application.contracts.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = _leaveTypeRepository;

            RuleFor(p => p.leaveTypeId).GreaterThan(0)
                                       .MustAsync(LeaveTypeMusExist)
                                       .WithMessage("{PropertyName} does not exist");
        }

        private async Task<bool> LeaveTypeMusExist(int id , CancellationToken arg2)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);

            return leaveType != null;
        }

    }
}
