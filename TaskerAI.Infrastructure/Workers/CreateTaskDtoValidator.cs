namespace TaskerAI.Infrastructure.Workers
{
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Dto;

    public class CreateTaskDtoValidator : BaseValidator<TaskDto>
    {
        public CreateTaskDtoValidator()
        {
            Required(p => p.Name);
            ValidDateFormat(p => p.Date);
            ValidDateFormat(p => p.DueDate);
            Required(p => p.DurationInSeconds);
            When(p => string.IsNullOrWhiteSpace(p.Location.Alias), () =>
            {
                Required(p => p.Location.Street);
                Required(p => p.Location.Door);
                Required(p => p.Location.ZipCode);
                Required(p => p.Location.City);
                Required(p => p.Location.Country);
            });
        }
    }
}
