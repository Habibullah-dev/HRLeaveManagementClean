using AutoMapper;
using HR.LeaveManangement.Application.contracts.Logging;
using HR.LeaveManangement.Application.contracts.persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,IAppLogger<GetLeaveTypesQueryHandler> logger) {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //Query the database

            var leavetypes = await _leaveTypeRepository.GetAsync();

            //convert data object to dto

            var data = _mapper.Map<List<LeaveTypeDto>>(leavetypes);

            //return list of dto object

            _logger.LogInformation("Leave types were retrieved successfully");

            return data;
        }
    }
}
