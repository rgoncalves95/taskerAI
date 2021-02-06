namespace TaskerAI.MockRepository.MockData
{
    using System.Collections.Generic;
    using TaskerAI.Domain;

    public class TaskTypeMockData
    {
        public static IEnumerable<TaskType> DatabaseSeed()
        {
            return new[]
            {
                TaskType.Create("cleaning", 10.0, 3600, 1),
                TaskType.Create("delivery", 20.0, 1800, 2),
                TaskType.Create("check in", 3600, 3),
                TaskType.Create("wtv only with cost", 175.50, 4)
            };
        }
    }
}
