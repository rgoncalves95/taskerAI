using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskerAI.Api.Models;
using TaskerAI.Application;
using TaskerAI.Domain;
using TaskerAI.Infrastructure;

namespace TaskerAI.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Post(PlanModel model)
        {
            return CreatedAtAction(nameof(PlanController.Post), await this.mediator.Send(new CreatePlanCommand(model.Name, model.Description)));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(mapper.Map(await this.mediator.Send(new GetPlanQuery(id))));
        }

        [HttpGet("GetAllTasks")]
        public async Task<PlanModel> GetAllTasks(int id)
        {
            var plan = await this.mediator.Send(new GetPlanQuery(id));
            var planModel = new PlanModel();

            mapper.Map(plan, planModel);

            return planModel;
        }

    }
}
