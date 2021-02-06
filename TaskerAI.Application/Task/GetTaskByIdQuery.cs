namespace TaskerAI.Application
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class GetTaskByIdQuery : IRequest<Domain.Task>
    {
        public int Id { get; }

        public GetTaskByIdQuery(int id) => this.Id = id;
    }

    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Domain.Task>
    {
        private readonly ITaskRepository repo;

        public GetTaskByIdQueryHandler(ITaskRepository repo) => this.repo = repo;

        public async Task<Domain.Task> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken) => await this.repo.GetAsync(request.Id);
    }
}
