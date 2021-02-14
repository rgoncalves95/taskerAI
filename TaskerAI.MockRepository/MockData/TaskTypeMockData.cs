namespace TaskerAI.MockRepository.MockData
{
    using System.Collections.Generic;
    using TaskerAI.Domain.Entities;

    public class TaskTypeMockData
    {
        public static IEnumerable<TaskType> DatabaseSeed()
        {
            return new[]
            {

                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                TaskType.Create("Cleaning 2BR apt.", 15.0, 4800, 2),
                TaskType.Create("Cleaning 3BR apt.", 20.0, 6000, 3),
                TaskType.Create("Cleaning 4BR apt.", 25.0, 7200, 4),
                TaskType.Create("Cleaning 5BR apt.", 30.0, 8400, 5),
                TaskType.Create("delivery", 20.0, 600, 6),
                TaskType.Create("Check in",10.0, 1200, 7),
                TaskType.Create("Start",0.0, 0, 8),
                TaskType.Create("Maintenance",0.0, 3600, 9)

            };
        }
    }
}
