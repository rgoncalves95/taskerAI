﻿namespace TaskerAI.Swagger
{
    using Swashbuckle.AspNetCore.Filters;
    using System;
    using System.Diagnostics.CodeAnalysis;
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
}