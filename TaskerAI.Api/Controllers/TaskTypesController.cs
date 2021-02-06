namespace TaskerAI.Api.Controllers
{
    using TaskerAI.Application;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TaskerAI.Api.Models;
    using TaskerAI.Common;

    [ApiController]
    [Route("[controller]")]
    public class TaskTypesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Domain.TaskType, TaskTypeModel> mapper;

        public TaskTypesController(IMediator mediator, IMapper<Domain.TaskType, TaskTypeModel> mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
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
