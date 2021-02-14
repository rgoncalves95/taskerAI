namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;

    public class CreateTaskTypeCommand : IRequest<TaskType>
    {
        public CreateTaskTypeCommand(string name, double? cost, int? duration)
        {
            this.Name = name;
            this.Cost = cost;
            this.Duration = duration;
        }

        public string Name { get; }
        public double? Cost { get; }
        public int? Duration { get; }
    }

    public class CreateTaskTypeCommandHandler : IRequestHandler<CreateTaskTypeCommand, TaskType>
    {
        private readonly ITaskTypeRepository repository;

        public CreateTaskTypeCommandHandler(ITaskTypeRepository repository) => this.repository = repository;

        public Task<TaskType> Handle(CreateTaskTypeCommand request, CancellationToken cancellationToken) => this.repository.CreateAsync(TaskType.Create(request.Name, request.Cost, request.Duration));
    }
}