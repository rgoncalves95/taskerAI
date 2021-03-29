﻿namespace TaskerAI.Api.Controllers
{
    using System.IO;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TaskerAI.Api.Models;
    using TaskerAI.Application;

    [ApiController]
    [Route("/Jobs/{jobId}/Batch")]
    public class BatchController : ControllerBase
    {
        private readonly IMediator mediator;

        public BatchController(IMediator mediator) => this.mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(BatchModel), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> Post([FromRoute] string jobId, [FromForm] BatchModel model)
        {
            using (var stream = new MemoryStream())
            {
                await model.File.CopyToAsync(stream);

                string id = await this.mediator.Send(new EnqueueBatchOperationCommand(jobId, model.Entity, model.File.ContentType, stream.ToArray()));

                return Accepted(new { Id = id, JobId = jobId });
            }
        }
    }
}
