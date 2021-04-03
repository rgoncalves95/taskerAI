namespace TaskerAI.Database.Repository
{
    using System;
    using System.Data;

    class Mapper 
    {
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
