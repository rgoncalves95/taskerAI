namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.Infrastructure.Workers;

    public class EnqueueBatchOperationCommand : IRequest<string>
    {
        public EnqueueBatchOperationCommand(string jobId, string entityType, string contentType, byte[] content, string body)
        {
            this.JobId = jobId;
            this.EntityType = entityType;
            this.ContentType = contentType;
            this.Content = content;
            this.Body = body;
        }

        public string JobId { get; }
        public string EntityType { get; }
        public string ContentType { get; }
        public byte[] Content { get; }
        public string Body { get;  }
    }

    public class EnqueueBatchOperationCommandHandler : IRequestHandler<EnqueueBatchOperationCommand, string>
    {
        private readonly IWorkerOperationRepository repository;
        private readonly IWorkerManager workerManager;

        public EnqueueBatchOperationCommandHandler(IWorkerOperationRepository repository, IWorkerManager workerManager)
        {
            this.repository = repository;
            this.workerManager = workerManager;
        }

        public async Task<string> Handle(EnqueueBatchOperationCommand request, CancellationToken cancellationToken)
        {
            string id = await this.repository.CreateAsync(request.JobId, request.EntityType, request.ContentType, request.Content, request.Body);

            this.workerManager.Enqueue(request.JobId, id);

            return id;
        }
    }
}