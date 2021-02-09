namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class GetTaskTypeByIdQuery : IRequest<TaskType>
    {
        public GetTaskTypeByIdQuery(int id) => this.Id = id;

        public int Id { get; }
    }

    public class GetTaskTypeByIdQueryHandler : IRequestHandler<GetTaskTypeByIdQuery, TaskType>
    {
        private readonly ITaskTypeRepository repository;

        public GetTaskTypeByIdQueryHandler(ITaskTypeRepository repository) => this.repository = repository;

        public Task<TaskType> Handle(GetTaskTypeByIdQuery request, CancellationToken cancellationToken) => this.repository.GetAsync(request.Id);
    }
}