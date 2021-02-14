namespace TaskerAI.MockRepository.MockData
{
    using System;
    using System.Collections.Generic;
    using TaskerAI.Domain;

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
                Location.Create(41.1591718, -8.6032467),
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
                Location.Create(41.1570408, -8.6092863),
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
                Location.Create(41.1609995, -8.6318888),
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
             Location.Create(41.1344532, -8.6072402),
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
                Location.Create(41.1507612, -8.6121278),
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
               Location.Create(41.1507612, -8.6121278),
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
           Location.Create(41.1480466, -8.6008611),
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
                Location.Create(41.1480466, -8.6008612),
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
              Location.Create(41.1461493, -8.6047536),
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
          Location.Create(41.1601259, -8.6074517),
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
        Location.Create(41.1551315, -8.6792639),
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
        Location.Create(41.2431481, -8.7239239),
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
             Location.Create(41.1518283, -8.603998),
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
           Location.Create(41.1518283, -8.603998),
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
           Location.Create(41.1532732, -8.6469867),
           DateTimeOffset.Now,
           DateTimeOffset.Now.AddHours(2),
           4800,
           "some notes that we take",
           TaskStatus.Draft,
                null,
                id++
       ));


            //check ins

            result.Add(Task.Create
       (
           "Clean Apt 8",
           TaskType.Create("Check in", 10.0, 1200, 7),
           Location.Create(41.1480466, -8.6008612),
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
              Location.Create(41.1461493, -8.6047536),
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
          Location.Create(41.1601259, -8.6074517),
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
        Location.Create(41.1551315, -8.6792639),
        DateTimeOffset.Now,
        DateTimeOffset.Now.AddHours(4),
        1200,
        "some notes that we take",
        TaskStatus.Draft,
                null,
                id++
    ));


            // maintenance

            result.Add(Task.Create
            (
                "Maintenance Apt 7",
                TaskType.Create("Maintenance", 0.0, 3600, 9),
                Location.Create(41.1480466, -8.6008611),
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
