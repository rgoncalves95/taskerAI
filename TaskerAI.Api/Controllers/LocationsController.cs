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
    using TaskerAI.Domain.Entities;

    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper<Location, LocationModel> mapper;
        private readonly IWebHostEnvironment host;

        public LocationsController(IMediator mediator, IMapper<Location, LocationModel> mapper, IWebHostEnvironment host)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.host = host;
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

        [HttpGet("BatchFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            Stream stream = this.host.ContentRootFileProvider.GetFileInfo(Path.Combine("Resources", "locations.xlsx")).CreateReadStream();

            return new FileStreamResult(stream, new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")) 
            { 
                FileDownloadName = "locations"
            };
        }
    }
}
