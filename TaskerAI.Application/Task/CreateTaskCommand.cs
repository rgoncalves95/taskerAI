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
        public CreateTaskCommand(string name,
                                 int typeId,
                                 int duration,
                                 DateTimeOffset date,
                                 DateTimeOffset dueDate,
                                 string street,
                                 string door,
                                 string floor,
                                 string zipCode,
                                 string city,
                                 string country,
                                 string latitude,
                                 string longitude,
                                 string alias,
                                 string[] tags,
                                 string notes)
        {
            this.Name = name;
            this.TypeId = typeId;
            this.DurationInSeconds = duration;
            this.Date = date;
            this.DueDate = dueDate;
            this.Street = street;
            this.Door = door;
            this.Floor = floor;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Alias = alias;
            this.Tags = tags;
            this.Notes = notes;
        }

        public string Name { get; }
        public int TypeId { get; }
        public int Location { get; }
        public int DurationInSeconds { get; }
        public DateTimeOffset Date { get; }
        public DateTimeOffset DueDate { get; }
        public string Street { get; }
        public string Door { get; }
        public string Floor { get; }
        public string ZipCode { get; }
        public string City { get; }
        public string Country { get; }
        public string Latitude { get; }
        public string Longitude { get; }
        public string Alias { get; }
        public string[] Tags { get; }
        public string Notes { get; }

        internal Domain.Entities.Task AsDomainEntity()
        {
            return Domain.Entities.Task.Create
            (
                this.Name,
                TaskType.Create(this.TypeId),
                Domain.Entities.Location.Create(this.Street, this.Door, this.Floor, this.ZipCode, this.City, this.Country, this.Latitude, this.Longitude, this.Alias, this.Tags),
                this.Date,
                this.DueDate,
                this.DurationInSeconds,
                this.Notes
            );
        }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Domain.Entities.Task>
    {
        private readonly ITaskRepository taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository) => this.taskRepository = taskRepository;

        public async Task<Domain.Entities.Task> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
            => await this.taskRepository.CreateAsync(request.AsDomainEntity());
    }
}