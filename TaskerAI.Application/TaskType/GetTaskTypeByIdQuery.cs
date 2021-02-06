namespace TaskerAI.Application
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
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

        public async Task<TaskType> Handle(GetTaskTypeByIdQuery request, CancellationToken cancellationToken) => await this.repository.GetAsync(request.Id);
    }
}