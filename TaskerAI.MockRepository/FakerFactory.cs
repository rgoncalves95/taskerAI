namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Bogus;
    using TaskerAI.Domain;

    internal static class FakerFactory
    {
        public static Plan CreatePlan(int id)
        {
            var planFaker = new Faker<Plan>()
                .RuleFor(o => o.Id, f => id)
                .RuleFor(o => o.Accountable, f => CreateAssignee())
                .RuleFor(o => o.Date, f => DateTimeOffset.Now.AddDays(1))
                .RuleFor(o => o.Name, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Responsible, f => CreateAdmin())
                .RuleFor(o => o.Status, f => f.Random.Int(0, 5))
                .RuleFor(o => o.Tasks, f => new[] { CreateTask(), CreateTask(), CreateTask(), CreateTask() })
                .RuleFor(o => o.TotalDurationInMins, f => f.Random.Int(60, 120));

            return planFaker.Generate();
        }

        public static Task CreateTask()
        {
            var taskFaker = new Faker<Task>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.DueDate, f => DateTimeOffset.Now.AddDays(1))
                .RuleFor(o => o.Duration, f => f.Random.Int(60, 120))
                .RuleFor(o => o.FinishDate, f => DateTimeOffset.MinValue)
                .RuleFor(o => o.Location, f => CreateLocation())
                .RuleFor(o => o.Name, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Notes, f => f.Lorem.Sentences(2))
                .RuleFor(o => o.Position, f => f.Random.Int(0, 10))
                .RuleFor(o => o.Status, f => f.Random.Int(0, 5))
                .RuleFor(o => o.Type, f => CreateTaskType());                

            return taskFaker.Generate();
        }

        public static Task CreateTask(int id)
        {
            var taskFaker = new Faker<Task>()
                .RuleFor(o => o.Id, f => id)
                .RuleFor(o => o.DueDate, f => DateTimeOffset.Now.AddDays(1))
                .RuleFor(o => o.Duration, f => f.Random.Int(60, 120))
                .RuleFor(o => o.FinishDate, f => DateTimeOffset.MinValue)
                .RuleFor(o => o.Location, f => CreateLocation())
                .RuleFor(o => o.Name, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Notes, f => f.Lorem.Sentences(2))
                .RuleFor(o => o.Position, f => f.Random.Int(0, 10))
                .RuleFor(o => o.Status, f => f.Random.Int(0, 5))
                .RuleFor(o => o.Type, f => CreateTaskType());

            return taskFaker.Generate();
        }

        public static TaskType CreateTaskType()
        {
            var taskTypeFaker = new Faker<TaskType>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Cost, f => f.Random.Double(60, 120))
                .RuleFor(o => o.DurationInSeconds, f => f.Random.Int(1200, 3600))
                .RuleFor(o => o.Location, f => CreateLocation())
                .RuleFor(o => o.Name, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Properties, f => null);

            return taskTypeFaker.Generate();
        }

        public static Location CreateLocation()
        {
            var locationFaker = new Faker<Location>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.Country, f => f.Address.Country())
                .RuleFor(o => o.Floor, f => f.Lorem.Word())
                .RuleFor(o => o.Lat, f => f.Address.Latitude())
                .RuleFor(o => o.Lon, f => f.Address.Longitude())
                .RuleFor(o => o.Number, f => f.Address.BuildingNumber())
                .RuleFor(o => o.User, f => CreateAssignee())
                .RuleFor(o => o.ZipCode, f => f.Address.ZipCode());

            return locationFaker.Generate();
        }

        public static Assignee CreateAssignee()
        {
            var assigneeFaker = new Faker<Assignee>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.LastName, f => f.Person.LastName)
                .RuleFor(o => o.ListAvailability, f => new List<Availability> { CreateAvailability(), CreateAvailability(), CreateAvailability() });

            return assigneeFaker.Generate();
        }

        public static Admin CreateAdmin()
        {
            var adminFaker = new Faker<Admin>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.LastName, f => f.Person.LastName)
                .RuleFor(o => o.ListAvailability, f => new List<Availability> { CreateAvailability(), CreateAvailability(), CreateAvailability() });

            return adminFaker.Generate();
        }

        public static Availability CreateAvailability()
        {
            var faker = new Faker();
            var date1 = faker.Date.BetweenOffset(DateTimeOffset.Now.AddDays(1), DateTimeOffset.Now.AddDays(2));
            var date2 = faker.Date.BetweenOffset(DateTimeOffset.Now.AddDays(1), DateTimeOffset.Now.AddDays(2));
            var availabilityFaker = new Faker<Availability>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.EndDate, f => date1 > date2 ? date1 : date2)
                .RuleFor(o => o.StartDate, f => date1 > date2 ? date2 : date1)
                .RuleFor(o => o.User, f => null);
                

            return availabilityFaker.Generate();
        }
    }
}
