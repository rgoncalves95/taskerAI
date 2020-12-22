namespace TaskerAI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Infrastructure;

    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Domain.Task, TaskModel> mapper;

        public TaskController(IMediator mediator, IMapper<Domain.Task, TaskModel> mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(mapper.Map(await mediator.Send(new GetTasksQuery())));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(mapper.Map(await mediator.Send(new GetTaskByIdQuery(id))));

        [HttpPost]
        public async Task<IActionResult> Post(List<TaskModel> model) =>
            //return CreatedAtAction
            //(
            //    nameof(TaskController.Post),
            //    await mediator.Send
            //    (
            //        new CreatePlanCommand
            //        (
            //            model.Tasks,
            //            model.Location?.Lat,
            //            model.Location?.Long,
            //            model.MaxTimeForPlan,
            //            model.MaxNumberOfTasks
            //        )
            //    )
            //);

            null;
    }
}
