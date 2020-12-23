namespace TaskerAI.Controllers
{
    using System.Collections.Generic;
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
        public async Task<IActionResult> Post(TaskModel model)
        {
            var result = mapper.Map(await mediator.Send(new CreateTaskCommand()));

            return CreatedAtAction(nameof(TasksController.Post), new { result.Id }, result);
        }

        [HttpPost]
        public IActionResult Post(IEnumerable<TaskModel> models)
        {
            var commands = models.Select(m => new CreateTaskCommand(m.Email, m.LastName, m.FirstName, m.Phone));

            System.Threading.Tasks.Task.WhenAll(mediator.Send(commands));

            return Accepted();
        }
    }
}
