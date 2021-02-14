namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;

    public class UpdateTaskTypeCommand : IRequest<TaskType>
    {
        public UpdateTaskTypeCommand(int? id, string name, double? cost, int? duration)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.Duration = duration;
        }

        public int? Id { get; }
        public string Name { get; }
        public double? Cost { get; }
        public int? Duration { get; }
    }

    public class UpdateTaskTypeCommandHandler : IRequestHandler<UpdateTaskTypeCommand, TaskType>
    {
        private readonly ITaskTypeRepository repository;

        public UpdateTaskTypeCommandHandler(ITaskTypeRepository repository) => this.repository = repository;

        public Task<TaskType> Handle(UpdateTaskTypeCommand request, CancellationToken cancellationToken) => this.repository.UpdateAsync(TaskType.Create(request.Name, request.Cost, request.Duration, request.Id));
    }
}