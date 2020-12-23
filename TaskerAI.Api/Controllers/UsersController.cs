namespace TaskerAI.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TaskerAI.Api.Models;
    using TaskerAI.Application.User;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure;

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
        )
        {
            return Ok(await this.mediator.Send(new GetUsersQuery(availabilityStartDate, availabilityEndDate, latitude, longitude, name)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await this.mediator.Send(new GetUserByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            var result = this.mapper.Map(await this.mediator.Send(new CreateUserCommand(model.Email, model.LastName, model.FirstName, model.Phone)));

            return CreatedAtAction(nameof(UserController.Post), new { result.Id }, result);
        }

        [HttpPost]
        public IActionResult Post(IEnumerable<UserModel> models)
        {
            var commands = models.Select(m => new CreateUserCommand(m.Email, m.LastName, m.FirstName, m.Phone));
            
            System.Threading.Tasks.Task.WhenAll(this.mediator.Send(commands));

            return Accepted();
        }
    }
}
