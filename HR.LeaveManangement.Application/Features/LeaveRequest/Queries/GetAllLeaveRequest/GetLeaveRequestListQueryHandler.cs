using AutoMapper;
using HR.LeaveManangement.Application.contracts.persistence;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest
{
    public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._mapper = mapper;
        }


        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
        {
            //Check if it is logged i employee

            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestWithDetails();

            var requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);

            //Fill request with employee information

            return requests;
        }
    }
}
