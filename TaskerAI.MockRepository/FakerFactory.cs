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
                .CustomInstantiator(f => new Plan(id, f.Lorem.Sentence(2)))
                .RuleFor(o => o.Accountable, f => CreateAssignee())
                .RuleFor(o => o.Date, f => DateTimeOffset.Now.AddDays(1))
                .RuleFor(o => o.Responsible, f => CreateAdmin())
                .RuleFor(o => o.Status, f => f.Random.Int(0, 5))
                .RuleFor(o => o.Tasks, f => new[] { CreateTask(), CreateTask(), CreateTask(), CreateTask() })
                .RuleFor(o => o.TotalDurationInMins, f => f.Random.Int(60, 120));

            return planFaker.Generate();
        }

        public static Task CreateTask()
        {
            var taskFaker = new Faker<Task>()
                .CustomInstantiator(f => new Task(
                    f.UniqueIndex,
                    f.Lorem.Sentence(2),
                    f.Random.Int(0, 5),
                    CreateTaskType(),
                    CreateLocation(),
                    DateTimeOffset.Now.AddDays(1),
                    DateTimeOffset.MinValue,
                    f.Random.Int(60, 120),
                    f.Random.Int(0, 10),
                    f.Lorem.Sentences(2)));
            
            return taskFaker.Generate();
        }

        public static Task CreateTask(int id)
        {
            var taskFaker = new Faker<Task>()
                .CustomInstantiator(f => new Task(
                    id,
                    f.Lorem.Sentence(2),
                    f.Random.Int(0, 5),
                    CreateTaskType(),
                    CreateLocation(),
                    DateTimeOffset.Now.AddDays(1),
                    DateTimeOffset.MinValue,
                    f.Random.Int(60, 120),
                    f.Random.Int(0, 10),
                    f.Lorem.Sentences(2)));

            return taskFaker.Generate();
        }

        public static TaskType CreateTaskType()
        {
            var taskTypeFaker = new Faker<TaskType>()
                .CustomInstantiator(f => new TaskType(
                    f.UniqueIndex,
                     f.Lorem.Sentence(2),
                     f.Random.Double(60, 120),
                     CreateLocation(),
                     f.Random.Int(1200, 3600),
                     null));
                
            return taskTypeFaker.Generate();
        }

        public static Location CreateLocation()
        {
            var locationFaker = new Faker<Location>()
                .CustomInstantiator(f => new Location(
                    f.Address.StreetName(),
                    f.Address.BuildingNumber(),
                    f.Lorem.Word(),
                    f.Address.ZipCode(),
                    f.Address.City(),
                    f.Address.Country(),
                    CreateAssignee()))
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Lat, f => f.Address.Latitude())
                .RuleFor(o => o.Lon, f => f.Address.Longitude());

            return locationFaker.Generate();
        }

        public static Assignee CreateAssignee()
        {
            var assigneeFaker = new Faker<Assignee>()
                .CustomInstantiator(f => new Assignee(
                    f.UniqueIndex,
                    f.Person.FirstName,
                    f.Person.LastName,
                    f.Person.Email,
                    new List<Availability> { CreateAvailability(), CreateAvailability(), CreateAvailability() }));

            return assigneeFaker.Generate();
        }

        public static Admin CreateAdmin()
        {
            var adminFaker = new Faker<Admin>()
                .CustomInstantiator(f => new Admin(
                 f.UniqueIndex,
                    f.Person.FirstName,
                    f.Person.LastName,
                    f.Person.Email,
                    new List<Availability> { CreateAvailability(), CreateAvailability(), CreateAvailability() }));

            return adminFaker.Generate();
        }

        public static Availability CreateAvailability()
        {
            var faker = new Faker();
            var date1 = faker.Date.BetweenOffset(DateTimeOffset.Now.AddDays(1), DateTimeOffset.Now.AddDays(2));
            var date2 = faker.Date.BetweenOffset(DateTimeOffset.Now.AddDays(1), DateTimeOffset.Now.AddDays(2));
            var availabilityFaker = new Faker<Availability>()
                .CustomInstantiator(f => new Availability(
                    f.UniqueIndex,
                    date1 > date2 ? date2 : date1,
                    date1 > date2 ? date1 : date2,
                    null));
               
            return availabilityFaker.Generate();
        }
    }
}
