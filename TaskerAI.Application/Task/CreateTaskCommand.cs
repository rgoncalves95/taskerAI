namespace TaskerAI.Application
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class CreateTaskCommand : IRequest<Domain.Task>
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

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Domain.Task>
    {
        private readonly ITaskRepository repo;

        public CreateTaskCommandHandler(ITaskRepository repo) => this.repo = repo;

        public async Task<Domain.Task> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await this.repo.CreateAsync
            (
                Domain.Task.Create
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