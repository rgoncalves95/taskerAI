namespace TaskerAI.Api.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using TaskerAI.Api.Attributes;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Common;

    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Domain.Entities.Task, TaskModel> mapper;
        private readonly IWebHostEnvironment host;

        public TasksController(IMediator mediator, IMapper<Domain.Entities.Task, TaskModel> mapper, IWebHostEnvironment host)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.host = host;
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
            Paged<Domain.Entities.Task> result = await this.mediator.Send(new GetTasksQuery(name, type, intervalStart, intervalEnd, status, pageSize, pageIndex, sortBy, sortAs));

            return Ok(result.Adapt(this.mapper));
        }

        [HttpGet("{id}", Name = RouteNames.TaskResource.GetById)]
        [ProducesResponseType(typeof(TaskModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            Domain.Entities.Task result = await this.mediator.Send(new GetTaskByIdQuery(id));

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
                    new CreateTaskCommand(model.Name,
                                          model.TypeId,
                                          model.Duration,
                                          model.Date,
                                          model.DueDate,
                                          model.Location.Street,
                                          model.Location.Door,
                                          model.Location.Floor,
                                          model.Location.ZipCode,
                                          model.Location.City,
                                          model.Location.Country,
                                          model.Location.Latitude,
                                          model.Location.Longitude,
                                          model.Location.Alias,
                                          model.Location.Tags,
                                          model.Notes)));

            return CreatedAtRoute(RouteNames.TaskResource.GetById, new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(TaskTypeModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, TaskModel model)
        {
            Domain.Entities.Task result = await this.mediator.Send(new UpdateTaskCommand(id, model.Name, model.TypeId, model.Location.Id ?? 0, model.Duration, model.Date, model.DueDate, model.Notes));

            if (result == null)
            {
                result = await this.mediator.Send(
                    new CreateTaskCommand(model.Name,
                                          model.TypeId,
                                          model.Duration,
                                          model.Date,
                                          model.DueDate,
                                          model.Location.Street,
                                          model.Location.Door,
                                          model.Location.Floor,
                                          model.Location.ZipCode,
                                          model.Location.City,
                                          model.Location.Country,
                                          model.Location.Latitude,
                                          model.Location.Longitude,
                                          model.Location.Alias,
                                          model.Location.Tags,
                                          model.Notes));

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

        [HttpGet("BatchFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            Stream stream = this.host.ContentRootFileProvider.GetFileInfo(Path.Combine("Resources", "tasks.xlsx")).CreateReadStream();

            return new FileStreamResult(stream, new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                FileDownloadName = "locations"
            };
        }
    }
}
