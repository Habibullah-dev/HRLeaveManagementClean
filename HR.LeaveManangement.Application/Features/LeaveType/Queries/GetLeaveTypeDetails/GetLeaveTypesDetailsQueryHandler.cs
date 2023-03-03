using AutoMapper;
using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypesDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveTypeRepository;

        public GetLeaveTypesDetailsQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypes == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);    

            return data;    
        }
    }
}
