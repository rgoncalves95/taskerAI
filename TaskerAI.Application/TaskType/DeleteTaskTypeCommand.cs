namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class DeleteTaskTypeCommand : IRequest<bool>
    {
        public DeleteTaskTypeCommand(int id) => this.Id = id;

        public int Id { get; }
    }

    public class DeleteTaskTypeCommandHandler : IRequestHandler<DeleteTaskTypeCommand, bool>
    {
        private readonly ITaskTypeRepository repository;

        public DeleteTaskTypeCommandHandler(ITaskTypeRepository repository) => this.repository = repository;

        public Task<bool> Handle(DeleteTaskTypeCommand request, CancellationToken cancellationToken) => this.repository.DeleteAsync(request.Id);
    }
}