namespace TaskerAI.MockRepository.MockData
{
    using System;
    using System.Collections.Generic;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;

    internal class TaskMockData
    {
        public static IEnumerable<Task> DatabaseSeed()
        {
            var result = new List<Task>();
            int id = 1;

            result.Add(Task.Create
            (
                "Clean Apt 1",
                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                LocationRepository.Db[0],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(1),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 2",
                TaskType.Create("Cleaning 2BR apt.", 15.0, 4800, 2),
                LocationRepository.Db[1],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(5),
                4800,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 3",
                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                LocationRepository.Db[2],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(3),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 4",
                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                LocationRepository.Db[3],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(3),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 5",
                TaskType.Create("Cleaning 2BR apt.", 15.0, 4800, 2),
                LocationRepository.Db[4],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(8),
                4800,
                "some notes that we take",
               TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 6",
                TaskType.Create("Cleaning 3BR apt.", 20.0, 6000, 3),
                LocationRepository.Db[5],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(4),
                6000,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 7",
                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                LocationRepository.Db[6],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(9),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 8",
                TaskType.Create("Cleaning 2BR apt.", 15.0, 4800, 2),
                LocationRepository.Db[7],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(2),
                4800,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 9",
                TaskType.Create("Cleaning 3BR apt.", 20.0, 6000, 3),
                LocationRepository.Db[8],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(2),
                6000,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 10",
                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                LocationRepository.Db[9],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(6),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
            "Clean Apt 11",
                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                LocationRepository.Db[10],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(4),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));


            result.Add(Task.Create
            (
                "Clean Apt 12",
                TaskType.Create("Cleaning 1BR apt.", 10.0, 3600, 1),
                LocationRepository.Db[11],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(4),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 13",
                TaskType.Create("Cleaning 3BR apt.", 20.0, 6000, 3),
                LocationRepository.Db[12],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(6),
                6000,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Clean Apt 14",
                TaskType.Create("Cleaning 2BR apt.", 15.0, 4800, 2),
                LocationRepository.Db[13],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(7),
                4800,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));


            result.Add(Task.Create
            (
                "Clean Apt 15",
                TaskType.Create("Cleaning 2BR apt.", 15.0, 4800, 2),
                LocationRepository.Db[14],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(2),
                4800,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Check in Apt 8",
                TaskType.Create("Check in", 10.0, 1200, 7),
                LocationRepository.Db[15],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(2),
                1200,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Check in Apt 9",
                TaskType.Create("Check in", 10.0, 1200, 7),
                LocationRepository.Db[16],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(2),
                1200,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Check in Apt 10",
                TaskType.Create("Check in", 10.0, 1200, 7),
                LocationRepository.Db[17],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(6),
                1200,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Check in Apt 11",
                TaskType.Create("Check in", 10.0, 1200, 7),
                LocationRepository.Db[18],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(4),
                1200,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            result.Add(Task.Create
            (
                "Maintenance Apt 7",
                TaskType.Create("Maintenance", 0.0, 3600, 9),
                LocationRepository.Db[19],
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddHours(3),
                3600,
                "some notes that we take",
                TaskStatus.Draft,
                null,
                id++
            ));

            return result;
        }
    }
}
