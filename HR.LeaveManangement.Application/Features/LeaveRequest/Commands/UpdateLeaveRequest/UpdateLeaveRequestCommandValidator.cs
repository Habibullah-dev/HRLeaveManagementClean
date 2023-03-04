using FluentValidation;
using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Features.LeaveRequest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._leaveRequestRepository = leaveRequestRepository;

            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

            RuleFor(p => p.Id).NotNull().MustAsync(LeaveRequestMustExist).WithMessage("{PropertyName} must be present");

        }

        private async Task<bool> LeaveRequestMustExist(int arg1, CancellationToken arg2)
        {
            var leaveAllocation = await _leaveRequestRepository.GetByIdAsync(arg1);

            return leaveAllocation != null;
        }

    }
}
