namespace TaskerAI.Application
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class CreateTaskCommand : IRequest<Domain.Task>
    {
        public CreateTaskCommand(string name, int typeId, int duration, DateTimeOffset dueDate, int locationId, string notes)
        {
            Name = name;
            TypeId = typeId;
            DurationInSeconds = duration;
            DueDate = dueDate;
            LocationId = locationId;
            Notes = notes;
        }

        public string Name { get; }
        public int TypeId { get; }
        public int DurationInSeconds { get; }
        public DateTimeOffset Date { get; }
        public DateTimeOffset DueDate { get; }
        public int LocationId { get; }
        public string Notes { get; }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Domain.Task>
    {
        private readonly ITaskRepository repo;

        public CreateTaskCommandHandler(ITaskRepository repo) => this.repo = repo;

        public async Task<Domain.Task> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await this.repo.CreateAsync(Domain.Task.Create(request.Name, null, null, request.Date, request.DueDate, request.DurationInSeconds, request.Notes));
        }
    }
}