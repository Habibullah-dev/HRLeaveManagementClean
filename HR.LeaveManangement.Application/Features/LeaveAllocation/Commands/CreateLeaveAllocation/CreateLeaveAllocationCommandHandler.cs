using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Any()) {
                throw new BadRequestException("Invalid leave Allocation Request", validationResult);
            }

            //Get Leave Type For Allocating
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.leaveTypeId);

            //Get Employee


            //Get Period

            //Assign Allocations

            var leaveAllocation = _mapper.Map<LeaveManagement.Domain.LeaveAllocation>(request);

            await _leaveAllocationRepository.CreateAsync(leaveAllocation);

            return Unit.Value;



        }
    }
}
