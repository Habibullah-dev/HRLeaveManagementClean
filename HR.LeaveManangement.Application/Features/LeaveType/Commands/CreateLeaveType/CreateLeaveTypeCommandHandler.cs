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

namespace HR.LeaveManangement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);

            var validatorResult = await  validator.ValidateAsync(request, cancellationToken);   

            if (!validatorResult.IsValid || validatorResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leavetype", validatorResult);
            }

            //convert to domain entity object

            var leaveTypetoCreate = _mapper.Map<LeaveManagement.Domain.LeaveType>(request);

            //add to database

            await _leaveTypeRepository.CreateAsync(leaveTypetoCreate);

            //return id

            return leaveTypetoCreate.Id;
        }
    }
}
