using System;
using MediatR;
using TaskerAI.Domain;

namespace TaskerAI.Application
{
    public class CreateTaskCommand : IRequest<Task>
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
}