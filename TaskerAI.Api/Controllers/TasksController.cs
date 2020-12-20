namespace TaskerAI.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get() => Ok(mapper.Map(await mediator.Send(new GetTasksQuery())));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(mapper.Map(await mediator.Send(new GetTaskByIdQuery(id))));

        [HttpPost]
        public Task<IActionResult> Post(TaskModel[] models) => models.Length > 1 ? Create(models) : Create(models.First());

        private async Task<IActionResult> Create(TaskModel model)
        {
            var result = mapper.Map(await mediator.Send(new CreateTaskCommand(model.Name, model.Notes, model.LocationId, model.Duration, model.TypeId, model.DueDate)));

            return CreatedAtAction(nameof(TasksController.Post), new { result.Id }, result);
        }

        private Task<IActionResult> Create(TaskModel[] models)
        {
            var commands = models.Select(m => new CreateTaskCommand(m.Name, m.Notes, m.LocationId, m.Duration, m.TypeId, m.DueDate));

            Task.WhenAll(mediator.Send(commands));

            return Task.FromResult((IActionResult)Accepted());
        }
    }
}
