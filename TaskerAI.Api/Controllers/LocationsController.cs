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
    using TaskerAI.Domain.Entities;

    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Location, LocationModel> mapper;

        public LocationsController(IMediator mediator, IMapper<Location, LocationModel> mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paged<LocationModel[]>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get
        (
            string alias = null,
            [FromQuery] string[] tags = null,
            [Whitelist(10, 20, 30)] int? pageSize = 10,
            [FromQuery, Range(0, int.MaxValue)] int? pageIndex = 0,
            [FromQuery] string sortBy = null,
            [FromQuery] string sortAs = null
        )
        {
            Paged<Location> result = await this.mediator.Send(new GetLocationsQuery(alias, tags, pageSize, pageIndex, sortBy, sortAs));

            return Ok(result.Adapt(this.mapper));
        }
    }
}
