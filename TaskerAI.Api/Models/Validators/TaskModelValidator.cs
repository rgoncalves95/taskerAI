namespace TaskerAI.Api.Models.Validators
{
    public class TaskModelValidator : BaseValidator<TaskModel>
    {
        public TaskModelValidator()
        {
            Required(p => p.Name);
            Required(p => p.TypeId);
            Required(p => p.LocationId);
            Required(p => p.Date);
            Required(p => p.DueDate);
            Required(p => p.DurationInSeconds);
        }
    }
}
