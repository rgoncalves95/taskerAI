namespace TaskerAI.Api.Controllers
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
        public async Task<IActionResult> Post([FromForm] BatchModel model, [FromRoute] string jobId = "f9d7aeff-7d14-4528-a007-023c04b857e9")
        {
            using (var stream = new MemoryStream())
            {
                await model.File.CopyToAsync(stream);

                string id = await this.mediator.Send(new EnqueueBatchOperationCommand(jobId, model.Entity, model.File.ContentType, stream.ToArray(), model.Body));

                return Accepted(new { Id = id, JobId = jobId });
            }
        }
    }
}