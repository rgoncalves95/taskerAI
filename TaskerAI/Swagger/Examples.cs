namespace TaskerAI.Swagger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Swashbuckle.AspNetCore.Filters;
    using TaskerAI.Api.Models;

    [ExcludeFromCodeCoverage]
    public class TaskModelExample : IExamplesProvider<TaskModel>
    {
        public TaskModel GetExamples()
        {
            return new TaskModel
            {
                Name = $"Task A",
                TypeId = 1,
                LocationId = 1,
                Date = DateTimeOffset.UtcNow.AddDays(1),
                DueDate = DateTimeOffset.UtcNow.AddDays(2),
                DurationInSeconds = 3600,
                Notes = "dummy test note"
            };
        }
    }

    [ExcludeFromCodeCoverage]
    public class TaskTypeModelExample : IExamplesProvider<TaskTypeModel>
    {
        public TaskTypeModel GetExamples()
        {
            return new TaskTypeModel
            {
                Name = $"Task Type A",
                Cost = 50,
                Duration = 3600
            };
        }
    }
}
