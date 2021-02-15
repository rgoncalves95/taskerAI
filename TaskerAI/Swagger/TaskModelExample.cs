namespace TaskerAI.Swagger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Swashbuckle.AspNetCore.Filters;
    using TaskerAI.Api.Models;

    [ExcludeFromCodeCoverage]
    public class TaskModelExample : IExamplesProvider<TaskModel>
    {
        private readonly IExamplesProvider<LocationModel> locationExample;

        public TaskModelExample(IExamplesProvider<LocationModel> locationExample) => this.locationExample = locationExample;

        public TaskModel GetExamples()
        {
            return new TaskModel
            {
                Name = $"Task A",
                TypeId = 1,
                Location = this.locationExample.GetExamples(),
                Date = DateTimeOffset.UtcNow.AddDays(1),
                DueDate = DateTimeOffset.UtcNow.AddDays(2),
                Duration = 3600,
                Notes = "dummy test note"
            };
        }
    }
}
