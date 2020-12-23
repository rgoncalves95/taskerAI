namespace TaskerAI.Controllers
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure;

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
        public async Task<IActionResult> Get() => Ok(mapper.Map(await mediator.Send(new GetPlansQuery())));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(mapper.Map(await mediator.Send(new GetPlanByIdQuery(id))));

        [HttpPost]
        public async Task<IActionResult> Post(PlanModel model)
        {
            return CreatedAtAction
            (
                nameof(PlansController.Post),
                await mediator.Send
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

        [HttpPost("{id}/User/{userId}")]
        public async Task<IActionResult> Post(int id, int userId)
        {
            var result = await mediator.Send(new AssignPlanCommand(id, userId));

            return CreatedAtAction(nameof(PlansController.Post), new { id = 0 }, result); //TODO set correct id from PlanUser relation
        }
    }
}
