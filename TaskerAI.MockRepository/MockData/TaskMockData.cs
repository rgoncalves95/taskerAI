namespace TaskerAI.MockRepository.MockData
{
    using System;
    using System.Collections.Generic;
    using TaskerAI.Domain;

    internal class TaskMockData
    {
        public static List<Task> CreateDummyTasks()
        {
            var result = new List<Task>();

            int id = 1;
            for (int i = 0; i < 100; i++)
            {
                DateTimeOffset date = DateTimeOffset.Now.AddHours(i + 1);

                result.Add(Task.Create
                (
                    "Clean Office",
                    TaskType.Create("cleaning", 10.0, 3600, 1),
                    Location.Create(id),
                    date,
                    date,
                    3600,
                    "some notes that we take",
                    id++,
                    TaskStatus.Draft
                ));

                result.Add(Task.Create(
                    "Delivery goods",
                    TaskType.Create("delivery", 20.0, 1800, 2),
                    Location.Create(id),
                    date,
                    date,
                    1800,
                    "do'n't forget to take the trash",
                    id++,
                    TaskStatus.Draft
                ));

                result.Add(Task.Create(
                    "Check in beer",
                    TaskType.Create("check in", 10.0, 3600, 3),
                    Location.Create(id),
                    date,
                    date,
                    3600,
                    "get some peanuts with it",
                    id++,
                    TaskStatus.Draft
                ));
            }

            return result;
        }
    }
}
