using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Exceptions;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
  
        private readonly ILeaveAllocationRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveAllocationRepository leaveTypeRepository) => _leaveTypeRepository = leaveTypeRepository;
      

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //verify that record exists

            if (leaveTypeToDelete == null) {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            //remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);


            //return record id
            return Unit.Value;
        }
    }
}
