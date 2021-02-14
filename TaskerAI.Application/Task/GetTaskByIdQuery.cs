namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class GetTaskByIdQuery : IRequest<Domain.Entities.Task>
    {
        public int Id { get; }

        public GetTaskByIdQuery(int id) => this.Id = id;
    }

    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Domain.Entities.Task>
    {
        private readonly ITaskRepository repository;

        public GetTaskByIdQueryHandler(ITaskRepository repository) => this.repository = repository;

        public async Task<Domain.Entities.Task> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken) => await this.repository.GetAsync(request.Id);
    }
}
