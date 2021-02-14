namespace TaskerAI.Application
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;

    public class UpdateTaskCommand : IRequest<Domain.Entities.Task>
    {
        public UpdateTaskCommand(int id, string name, int typeId, int locationId, int durationInSeconds, DateTimeOffset date, DateTimeOffset dueDate, string notes)
        {
            this.Id = id;
            this.Name = name;
            this.TypeId = typeId;
            this.LocationId = locationId;
            this.DurationInSeconds = durationInSeconds;
            this.Date = date;
            this.DueDate = dueDate;
            this.Notes = notes;
        }

        public int Id { get; }
        public string Name { get; }
        public int TypeId { get; }
        public int LocationId { get; }
        public int DurationInSeconds { get; }
        public DateTimeOffset Date { get; }
        public DateTimeOffset DueDate { get; }
        public string Notes { get; }
    }

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Domain.Entities.Task>
    {
        private readonly ITaskRepository repository;

        public UpdateTaskCommandHandler(ITaskRepository repository) => this.repository = repository;

        public Task<Domain.Entities.Task> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return this.repository.UpdateAsync
            (
                Domain.Entities.Task.Create
                (
                    request.Name,
                    TaskType.Create(request.TypeId),
                    Location.Create(request.LocationId),
                    request.Date,
                    request.DueDate,
                    request.DurationInSeconds,
                    request.Notes,
                    request.Id
                )
            );
        }
    }
}