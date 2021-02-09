namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class DeleteTaskCommand : IRequest<bool>
    {
        public DeleteTaskCommand(int id) => this.Id = id;

        public int Id { get; }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskRepository repository;

        public DeleteTaskCommandHandler(ITaskRepository repository) => this.repository = repository;

        public Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken) => this.repository.DeleteAsync(request.Id);
    }
}