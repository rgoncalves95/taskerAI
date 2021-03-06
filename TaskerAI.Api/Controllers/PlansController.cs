﻿namespace TaskerAI.Api.Controllers
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Common;
    using TaskerAI.Domain;

    [ApiController]
    [Route("[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Plan, PlanModel> mapper;

        public PlansController(IMediator mediator, IMapper<Plan, PlanModel> mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(this.mapper.Map(await this.mediator.Send(new GetPlansQuery())));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(this.mapper.Map(await this.mediator.Send(new GetPlanByIdQuery(id))));

        [HttpPost]
        public async Task<IActionResult> Post(PlanModel model)
        {
            return CreatedAtAction
            (
                nameof(PlansController.Post),
                await this.mediator.Send
                (
                    new CreatePlanCommand
                    (
                        model.TaskIds,
                        model.LocationId,
                        model.MaxTimeForPlan,
                        model.MaxNumberOfTasks
                    )
                )
            );
        }

        [HttpPost("{id}/assign_user/{userId}")]
        public async Task<IActionResult> Post(int id, int userId)
        {
            return CreatedAtAction
            (
                nameof(PlansController.Post),
                await this.mediator.Send
                (
                    new AssignPlanCommand
                    (
                        id,
                        userId
                    )
                )
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<PlanModel> model)
        {
            PlanModel result = this.mapper.Map(await this.mediator.Send(new GetPlanByIdQuery(id)));

            model.ApplyTo(result);

            await this.mediator.Send(new UpdatePlanCommand
            (
                result.Id,
                result.TaskIds,
                result.MaxNumberOfTasks,
                result.MaxTimeForPlan,
                result.LocationId,
                result.SupervisorId,
                result.AssigneeId)
            );

            return NoContent();
        }
    }
}
