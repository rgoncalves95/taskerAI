namespace TaskerAI.Application
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Persistence;

    public class CreateTaskCommand : IRequest
    {
        public CreateTaskCommand(string name, string notes, int locationId, int duration, int typeId, DateTimeOffset dueDate)
        {
            Name = name;
            Notes = notes;
            LocationId = locationId;
            Duration = duration;
            TypeId = typeId;
            DueDate = dueDate;
        }

        public string Name { get; }
        public string Notes { get; }
        public int LocationId { get; }
        public int Duration { get; }
        public int TypeId { get; }
        public DateTimeOffset DueDate { get; }


    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
    {
        private readonly ITaskRepository repo;

        public CreateTaskCommandHandler(ITaskRepository repo) => this.repo = repo;

        public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            //var task = new Domain.Task();

            //insert task in the DB

            return Unit.Value;
        }
    }
}