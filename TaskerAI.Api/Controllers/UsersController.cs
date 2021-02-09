namespace TaskerAI.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;
    using TaskerAI.Common;
    using TaskerAI.Domain;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<User, UserModel> mapper;

        public UserController(IMediator mediator, IMapper<Domain.User, UserModel> mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get
        (
            DateTimeOffset? availabilityStartDate,
            DateTimeOffset? availabilityEndDate,
            string latitude,
            string longitude,
            string name
        ) => Ok(await this.mediator.Send(new GetUsersQuery(availabilityStartDate, availabilityEndDate, latitude, longitude, name)));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await this.mediator.Send(new GetUserByIdQuery(id)));

        [HttpPost]
        public Task<IActionResult> Post(UserModel[] models) => models.Length > 1 ? Create(models) : Create(models.First());

        private async Task<IActionResult> Create(UserModel model)
        {
            UserModel result = this.mapper.Map(await this.mediator.Send(new CreateUserCommand(model.Email, model.LastName, model.FirstName, model.Phone)));

            return CreatedAtAction(nameof(UserController.Post), new { result.Id }, result);
        }

        private Task<IActionResult> Create(UserModel[] models)
        {
            System.Collections.Generic.IEnumerable<CreateUserCommand> commands = models.Select(m => new CreateUserCommand(m.Email, m.LastName, m.FirstName, m.Phone));

            System.Threading.Tasks.Task.WhenAll(this.mediator.Send(commands));

            return System.Threading.Tasks.Task.FromResult((IActionResult)Accepted());
        }

        [HttpPost("{id}/accept_plan/{taskId}")]
        public async Task<IActionResult> Post(int userId, int taskId)
        {
            Plan result = await this.mediator.Send(new AcceptPlanCommand(userId, taskId));
            return Ok(result);
        }
    }
}
