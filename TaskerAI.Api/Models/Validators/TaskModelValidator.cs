using FluentValidation;

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
            RuleFor(p => p.DueDate).GreaterThan(p => p.Date);
            Required(p => p.DurationInSeconds);
        }
    }
}
