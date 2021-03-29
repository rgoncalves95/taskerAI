namespace TaskerAI.Api.Models.Validators
{
    using TaskerAI.Common;

    public class TaskTypeModelValidator : BaseValidator<TaskTypeModel>
    {
        public TaskTypeModelValidator() => Required(p => p.Name);
    }
}
