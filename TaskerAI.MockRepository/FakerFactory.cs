namespace TaskerAI.MockRepository
{
    using Bogus;
    using System;
    using System.Collections.Generic;
    using TaskerAI.Domain;

    internal static class FakerFactory
    {
        public static Plan CreatePlan(int id)
        {
            Faker<Plan> planFaker = new Faker<Plan>()
                .CustomInstantiator(f => Plan.Create(new[] { CreateTaskRoute(), CreateTaskRoute(), CreateTaskRoute(), CreateTaskRoute() }, DateTimeOffset.UtcNow));

            return CreatePlan(planFaker.Generate(), id);
        }

        public static Plan CreatePlan(Plan plan, int? id = null)
        {
            Faker<Plan> planFaker = new Faker<Plan>()
                .CustomInstantiator(f => Plan.Create(id ?? f.UniqueIndex, plan.TaskRoutes, plan.Date))
                .RuleFor(o => o.Accountable, f => CreateAssignee())
                .RuleFor(o => o.Date, f => DateTimeOffset.Now.AddDays(1))
                .RuleFor(o => o.Responsible, f => CreateAdmin())
                .RuleFor(o => o.Status, f => PlanWorkflowState.Draft);

            return planFaker.Generate();
        }

        public static TaskRoute CreateTaskRoute()
        {
            Faker<TaskRoute> taskFaker = new Faker<TaskRoute>()
                .CustomInstantiator(f => TaskRoute.Create(
                    CreateTask(),
                    CreateTask(),
                    f.Random.Decimal(100, 100000),
                    f.Random.Int(1800, 7200)));

            return taskFaker.Generate();
        }

        public static Task CreateTask()
        {
            Faker<Task> taskFaker = new Faker<Task>()
                .CustomInstantiator(f => Task.Create(
                    f.Lorem.Sentence(2),
                    CreateTaskType(),
                    CreateLocation(),
                    DateTimeOffset.Now.AddDays(1),
                    DateTimeOffset.Now.AddDays(2),
                    f.Random.Int(60, 120),
                    f.Lorem.Sentence(20)));

            return taskFaker.Generate();
        }

        public static Task CreateTask(int id)
        {
            Faker<Task> taskFaker = new Faker<Task>()
                .CustomInstantiator(f => Task.Create(
                    f.Lorem.Sentence(2),
                    CreateTaskType(),
                    CreateLocation(),
                    DateTimeOffset.Now.AddDays(1),
                    DateTimeOffset.Now.AddDays(2),
                    f.Random.Int(60, 120),
                    f.Lorem.Sentence(20),
                    id));

            return taskFaker.Generate();
        }

        public static TaskType CreateTaskType()
        {
            Faker<TaskType> taskTypeFaker = new Faker<TaskType>()
                .CustomInstantiator(f => TaskType.Create(
                    f.Lorem.Sentence(2),
                    f.Random.Double(60, 120),
                    f.Random.Int(1200, 3600),
                    null));

            return taskTypeFaker.Generate();
        }

        public static Location CreateLocation()
        {
            Faker<Location> locationFaker = new Faker<Location>()
                .CustomInstantiator(f => new Location(
                    f.Address.StreetName(),
                    f.Address.BuildingNumber(),
                    f.Lorem.Word(),
                    f.Address.ZipCode(),
                    f.Address.City(),
                    f.Address.Country()
                    ))
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Lat, f => f.Address.Latitude())
                .RuleFor(o => o.Lon, f => f.Address.Longitude());

            return locationFaker.Generate();
        }

        public static Assignee CreateAssignee()
        {
            Faker<Assignee> assigneeFaker = new Faker<Assignee>()
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
            Faker<Admin> adminFaker = new Faker<Admin>()
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
            DateTimeOffset date1 = faker.Date.BetweenOffset(DateTimeOffset.Now.AddDays(1), DateTimeOffset.Now.AddDays(2));
            DateTimeOffset date2 = faker.Date.BetweenOffset(DateTimeOffset.Now.AddDays(1), DateTimeOffset.Now.AddDays(2));
            Faker<Availability> availabilityFaker = new Faker<Availability>()
                .CustomInstantiator(f => new Availability(
                    f.UniqueIndex,
                    date1 > date2 ? date2 : date1,
                    date1 > date2 ? date1 : date2,
                    null));

            return availabilityFaker.Generate();
        }
    }
}
