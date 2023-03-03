using HR.LeaveManangement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using HR.LeaveManangement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManangement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManangement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get(bool isLoggedUser = false)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationListQuery());

            return Ok(leaveAllocation);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQuery
            {
                Id = id 
            });
            return Ok(leaveAllocation);
        }


        // POST api/<LeaveAllocationsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreateLeaveAllocationCommand leaveAllocation)
        {
            var response = await _mediator.Send(leaveAllocation);

            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(UpdateLeaveAllocationCommand leaveAllocation)
        {
            await _mediator.Send(leaveAllocation);

            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLeaveCommandAllocationCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
