namespace TaskerAI.Api.Models.Validators
{
    public class TaskTypeModelValidator : BaseValidator<TaskTypeModel>
    {
        public TaskTypeModelValidator()
        {
            Required(p => p.Name);
        }
    }
}
