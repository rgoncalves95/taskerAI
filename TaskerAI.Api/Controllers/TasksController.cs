namespace TaskerAI.Api.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TaskerAI.Api.Attributes;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Common;

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
        [ProducesResponseType(typeof(Paged<TaskModel[]>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get
        (
            string name,
            int? type,
            DateTimeOffset? intervalStart,
            DateTimeOffset? intervalEnd,
            int? status,
            [Whitelist(10, 20, 30)] int? pageSize = 10,
            [FromQuery, Range(0, int.MaxValue)] int? pageIndex = 0,
            [FromQuery] string sortBy = null,
            [FromQuery] string sortAs = null
        )
        {
            Paged<Domain.Task> result = await this.mediator.Send(new GetTasksQuery(name, type, intervalStart, intervalEnd, status, pageSize, pageIndex, sortBy, sortAs));

            return Ok(result.Adapt(this.mapper));
        }

        [HttpGet("{id}", Name = RouteNames.TaskResource.GetById)]
        [ProducesResponseType(typeof(TaskModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            Domain.Task result = await this.mediator.Send(new GetTaskByIdQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(TaskModel model)
        {
            TaskModel result = this.mapper.Map(
                await this.mediator.Send(
                    new CreateTaskCommand(model.Name, model.TypeId, model.LocationId, model.DurationInSeconds, model.Date, model.DueDate, model.Notes)));

            return CreatedAtRoute(RouteNames.TaskResource.GetById, new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, TaskModel model)
        {
            Domain.Task result = await this.mediator.Send(new UpdateTaskCommand(id, model.Name, model.TypeId, model.LocationId, model.DurationInSeconds, model.Date, model.DueDate, model.Notes));

            if (result == null)
            {
                result = await this.mediator.Send(new CreateTaskCommand(model.Name, model.TypeId, model.LocationId, model.DurationInSeconds, model.Date, model.DueDate, model.Notes));
                model = this.mapper.Map(result);

                return CreatedAtRoute(RouteNames.TaskResource.GetById, new { id = model.Id }, model);
            }

            model = this.mapper.Map(result);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteTaskCommand(id));

            return NoContent();
        }

        //[HttpPost("Batch")]
        //[ProducesResponseType(StatusCodes.Status202Accepted)]
        //public Task<IActionResult> Post(TaskModel[] models)
        //{
        //    System.Collections.Generic.IEnumerable<CreateTaskCommand> commands = models.Select(m => new CreateTaskCommand(m.Name, m.TypeId, m.LocationId, m.DurationInSeconds, m.Date, m.DueDate, m.Notes));

        //    Task.WhenAll(this.mediator.Send(commands));

        //    return Task.FromResult((IActionResult)Accepted());
        //}
    }
}
