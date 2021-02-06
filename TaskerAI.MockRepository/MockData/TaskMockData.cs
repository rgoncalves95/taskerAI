namespace TaskerAI.MockRepository.MockData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class TaskMockData
    {
        public static List<Domain.Task> CreateDummyTasks()
        {
            var result = new List<Domain.Task>();

            var task = Domain.Task.Create(
                "Clean Office",
                new Domain.TaskType(1, "cleaning", 10.0, null, 3600, null),
                null,
                DateTimeOffset.Now,
                DateTimeOffset.Now,
                3600,
                "some notes that we take",
                1,
                Domain.TaskStatus.Done,
                DateTimeOffset.Now
            );

            result.Add(task);

            task = Domain.Task.Create(
                "Delivery goods",
                new Domain.TaskType(2, "delivery", 20.0, null, 1800, null),
                null,
                DateTimeOffset.Now,
                DateTimeOffset.Now,
                1800,
                "do'n't forget to take the trash",
                2,
                Domain.TaskStatus.Done,
                DateTimeOffset.Now
            );

            result.Add(task);

            task = Domain.Task.Create(
                "Check in beer",
                new Domain.TaskType(3, "check in", 10.0, null, 3600, null),
                null,
                DateTimeOffset.Now,
                DateTimeOffset.Now,
                3600,
                "get some peanuts with it",
                3,
                Domain.TaskStatus.Done,
                DateTimeOffset.Now
            );

            result.Add(task);

            return result;
        }
    }
}
