namespace TaskerAI.Application
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;

    public class CreateTaskCommand : IRequest<Domain.Entities.Task>
    {
        public CreateTaskCommand(string name, int typeId, int locationId, int duration, DateTimeOffset date, DateTimeOffset dueDate, string notes)
        {
            this.Name = name;
            this.TypeId = typeId;
            this.LocationId = locationId;
            this.DurationInSeconds = duration;
            this.Date = date;
            this.DueDate = dueDate;
            this.Notes = notes;
        }

        public string Name { get; }
        public int TypeId { get; }
        public int LocationId { get; }
        public int DurationInSeconds { get; }
        public DateTimeOffset Date { get; }
        public DateTimeOffset DueDate { get; }
        public string Notes { get; }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Domain.Entities.Task>
    {
        private readonly ITaskRepository repository;

        public CreateTaskCommandHandler(ITaskRepository repository) => this.repository = repository;

        public async Task<Domain.Entities.Task> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.CreateAsync
            (
                Domain.Entities.Task.Create
                (
                    request.Name,
                    TaskType.Create(request.TypeId),
                    Location.Create(request.LocationId),
                    request.Date,
                    request.DueDate,
                    request.DurationInSeconds,
                    request.Notes
                )
            );
        }
    }
}