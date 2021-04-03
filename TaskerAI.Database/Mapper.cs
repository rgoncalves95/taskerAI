namespace TaskerAI.Database.Repository
{
    using System;
    using System.Data;

    class Mapper
    {
        public static Domain.Entities.Task map(TaskerAI.Database.Entities.Task task, IDbConnection db)
        {
            var taskTypeRep = new TaskTypeRepository(db);
            var locationRep = new LocationRepository(db);

            var newTask = Domain.Entities.Task.Create(task.Name, taskTypeRep.Get(task.IdType), locationRep.Get(task.IdLocation), task.Date, task.DueDate, task.DurationInSeconds, task.Notes, (Domain.TaskStatus)task.Status, (DateTimeOffset)task.FinishDate, task.Id);

            return newTask;


        }

        public static TaskerAI.Database.Entities.Task map(TaskerAI.Domain.Entities.Task task)
        {


            var newTask = new TaskerAI.Database.Entities.Task()
            {
                Id = (int)task.Id,
                Date = task.Date,
                DueDate = task.DueDate,
                DurationInSeconds = task.DurationInSeconds,
                FinishDate = task.FinishDate,
                IdLocation = (int)task.Location.Id,
                IdType = (int)task.Type.Id,
                Name = task.Name,
                Notes = task.Notes,
                Status = (int)task.Status

            };

            return newTask;


        }

        public static Domain.Entities.TaskType map(TaskerAI.Database.Entities.TaskType taskType)
        {
           

            var newTaskType = Domain.Entities.TaskType.Create(taskType.Name, taskType.Cost, taskType.Duration, taskType.Id);

            return newTaskType;


        }

        public static TaskerAI.Database.Entities.TaskType map(TaskerAI.Domain.Entities.TaskType taskType)
        {


            var newTaskType = new TaskerAI.Database.Entities.TaskType()
            {
                Id = (int)taskType.Id,
                Cost = taskType.Cost,
                Duration = taskType.Duration,
                Name = taskType.Name


            };

            return newTaskType;


        }

        public static Domain.Entities.Location map(TaskerAI.Database.Entities.Location location)
        {


            var newLocation = Domain.Entities.Location.Create(location.Street, location.Door, location.Floor, location.ZipCode, location.City, location.Country, location.Latitude, location.Longitude, "", null, location.Id);

            return newLocation;


        }

        public static TaskerAI.Database.Entities.Location map(TaskerAI.Domain.Entities.Location location)
        {


            var newLocation = new TaskerAI.Database.Entities.Location()
            {
                Id = (int)location.Id,
                City = location.City,
                Country = location.Country,
                Door = location.Door,
                Floor = location.Floor,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Street = location.Street,
                ZipCode = location.ZipCode
                


            };

            return newLocation;


        }

    }


}
