namespace TaskerAI.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using TaskerAI.Api.Attributes;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Common;
    using TaskerAI.Domain;

    [ApiController]
    [Route("[controller]")]
    public class TaskTypesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<TaskType, TaskTypeModel> mapper;

        public TaskTypesController(IMediator mediator, IMapper<TaskType, TaskTypeModel> mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paged<TaskTypeModel[]>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get
        (
            string name,
            double? cost,
            int? duration,
            [Whitelist(10, 20, 30)] int? pageSize = 10,
            [FromQuery, Range(0, int.MaxValue)] int? pageIndex = 0,
            [FromQuery] string sortBy = null,
            [FromQuery] string sortAs = null
        )
        {
            Paged<TaskType> result = await this.mediator.Send(new GetTaskTypesQuery(name, cost, duration, pageSize, pageIndex, sortBy, sortAs));

            return Ok(result.Adapt(this.mapper));
        }

        [HttpGet("{id}", Name = RouteNames.TaskTypeResource.GetById)]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            TaskType result = await this.mediator.Send(new GetTaskTypeByIdQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(TaskTypeModel model)
        {
            model = this.mapper.Map(
                await this.mediator.Send(
                    new CreateTaskTypeCommand(model.Name, model.Cost, model.Duration)));

            return CreatedAtRoute(RouteNames.TaskTypeResource.GetById, new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, TaskTypeModel model)
        {
            TaskType result = await this.mediator.Send(new UpdateTaskTypeCommand(id, model.Name, model.Cost, model.Duration));

            if (result == null)
            {
                result = await this.mediator.Send(new CreateTaskTypeCommand(model.Name, model.Cost, model.Duration));
                model = this.mapper.Map(result);

                return CreatedAtRoute(RouteNames.TaskTypeResource.GetById, new { id = model.Id }, model);
            }

            model = this.mapper.Map(result);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteTaskTypeCommand(id));

            return NoContent();
        }
    }
}
