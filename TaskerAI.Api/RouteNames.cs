namespace TaskerAI.Api
{
    using TaskerAI.Api.Controllers;

    public struct RouteNames
    {
        public struct TaskResource
        {
            public const string GetById = nameof(TasksController) + "." + nameof(TasksController.Get);
        }

        public struct TaskTypeResource
        {
            public const string GetById = nameof(TaskTypesController) + "." + nameof(TaskTypesController.Get);
        }
    }
}
