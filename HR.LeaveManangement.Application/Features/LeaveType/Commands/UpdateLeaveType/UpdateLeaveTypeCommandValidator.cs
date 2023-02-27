using FluentValidation;
using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.CreateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Id).NotNull().MustAsync(leaveTypeMustExist);

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required")
                                .NotNull()
                                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.DefaultDays)
                       .GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100")
                       .LessThan(70).WithMessage("{PropertyName} cannot be less than 1");
            RuleFor(q => q)
                        .MustAsync(LeaveTypeNameUnique)
                        .WithMessage("Leave type already exists");
            _leaveTypeRepository = leaveTypeRepository;
        }

        private async Task<bool> leaveTypeMustExist(int id, CancellationToken token)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);

            return leaveType != null;
        }

        private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
