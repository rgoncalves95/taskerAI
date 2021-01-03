namespace TaskerAI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Infrastructure;

    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Domain.Task, TaskModel> mapper;

        public TasksController(IMediator mediator, IMapper<Domain.Task, TaskModel> mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(this.mapper.Map(await this.mediator.Send(new GetTasksQuery())));

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> Get(int id) => Ok(this.mapper.Map(await this.mediator.Send(new GetTaskByIdQuery(id))));

        [HttpPost]
        [ProducesResponseType(typeof(TaskModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(TaskModel model)
        {
            TaskModel result = this.mapper.Map(
                await this.mediator.Send(
                    new CreateTaskCommand(model.Name, model.TypeId, model.LocationId, model.DurationInSeconds, model.Date, model.DueDate, model.Notes)));

            return CreatedAtRoute("GetById", new { id = result.Id }, result);
        }

        [HttpPost("Batch")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public Task<IActionResult> Post(TaskModel[] models)
        {
            System.Collections.Generic.IEnumerable<CreateTaskCommand> commands = models.Select(m => new CreateTaskCommand(m.Name, m.TypeId, m.LocationId, m.DurationInSeconds, m.Date, m.DueDate, m.Notes));

            Task.WhenAll(this.mediator.Send(commands));

            return Task.FromResult((IActionResult)Accepted());
        }
    }
}
