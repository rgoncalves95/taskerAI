namespace TaskerAI.Swagger
{
    using System.Diagnostics.CodeAnalysis;
    using Swashbuckle.AspNetCore.Filters;
    using TaskerAI.Api.Models;

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
