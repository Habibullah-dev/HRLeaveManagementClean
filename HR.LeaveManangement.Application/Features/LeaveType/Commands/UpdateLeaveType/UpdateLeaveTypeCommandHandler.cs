using AutoMapper;
using HR.LeaveManangement.Application.contracts.Logging;
using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

        public UpdateLeaveTypeCommandHandler(IMapper mapper , ILeaveTypeRepository leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation Errors In Update Request fot {0} - {1}" , nameof(LeaveType) , request.Id);

                 throw new BadRequestException("Invalid Leavetype", validatorResult);
            }


            var leaveTypeToUpdate = _mapper.Map<LeaveManagement.Domain.LeaveType>(request);

            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            return Unit.Value;

        }
    }
}
