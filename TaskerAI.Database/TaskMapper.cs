namespace TaskerAI.Database.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Common;

    public class TaskMapper : ITaskMapper
    {
        private readonly IMapper<Entities.TaskType, Domain.Entities.TaskType> taskTypeMapper;
        private readonly IMapper<Entities.Location, Domain.Entities.Location> locatioMapper;

        public TaskMapper(IMapper<Entities.TaskType, Domain.Entities.TaskType> taskTypeMapper, IMapper<Entities.Location, Domain.Entities.Location> locatioMapper)
        {
            this.taskTypeMapper = taskTypeMapper;
            this.locatioMapper = locatioMapper;
        }
        public void Map(Entities.Task from, Domain.Entities.Task to) => to = Map(from);

        public Domain.Entities.Task Map(Entities.Task from)
        {
            return Domain.Entities.Task.Create(from.Name,
                                               this.taskTypeMapper.Map(from.TaskType),
                                               this.locatioMapper.Map(from.Location),
                                               from.Date,
                                               from.DueDate,
                                               from.DurationInSeconds,
                                               from.Notes,
                                               (Domain.TaskStatus)from.Status,
                                               (DateTimeOffset)from.FinishDate,
                                               from.Id);
        }

        public void Map(IEnumerable<Entities.Task> from, IEnumerable<Domain.Entities.Task> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<Domain.Entities.Task> Map(IEnumerable<Entities.Task> from) => from.Select(f => Map(f)).ToArray();

        public void Map(Domain.Entities.Task from, Entities.Task to)
        {
            to.Id = from.Id;
            to.Date = from.Date;
            to.DueDate = from.DueDate;
            to.DurationInSeconds = from.DurationInSeconds;
            to.FinishDate = from.FinishDate;
            to.LocationId = from.Location.Id.Value;
            to.TaskTypeId = from.Type.Id.Value;
            to.Name = from.Name;
            to.Notes = from.Notes;
            to.Status = (int)from.Status;
        }

        public Entities.Task Map(Domain.Entities.Task from)
        {
            var to = new Entities.Task();
            this.Map(from, to);
            return to;
        }

        public void Map(IEnumerable<Domain.Entities.Task> from, IEnumerable<Entities.Task> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<Entities.Task> Map(IEnumerable<Domain.Entities.Task> from) => from.Select(f => Map(f)).ToArray();
    }

    public interface ITaskMapper : IMapper<Entities.Task, Domain.Entities.Task>, IMapper<Domain.Entities.Task, Entities.Task>
    {
    }
}
