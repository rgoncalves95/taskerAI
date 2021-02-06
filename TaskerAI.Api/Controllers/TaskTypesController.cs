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
            Paged<TaskType> response = await this.mediator.Send(new GetTaskTypesQuery(name, cost, duration, pageSize, pageIndex, sortBy, sortAs));
            return Ok(response.Adapt(this.mapper));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(TaskTypeModel model)
        {
            TaskTypeModel result = this.mapper.Map(
                await this.mediator.Send(
                    new CreateTaskTypeCommand(model.Name, model.Cost, model.Duration)));

            return CreatedAtRoute("GetById", new { id = result.Id }, result);
        }
    }
}
