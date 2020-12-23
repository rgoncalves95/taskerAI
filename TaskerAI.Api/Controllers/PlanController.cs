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
    public class PlanController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Plan, PlanModel> mapper;

        public PlanController(IMediator mediator, IMapper<Plan, PlanModel> mapper)
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
                nameof(PlanController.Post),
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

        [HttpPost("AssignPlan")]
        public async Task<IActionResult> AssignPlan(PlanModel model, int idUser)
        {
            return CreatedAtAction
            (
                nameof(PlanController.Post),
                await mediator.Send
                (
                    new AssignPlanCommand
                    (
                        model.Id,
                        idUser
                    )
                )
            );
        }
    }
}
