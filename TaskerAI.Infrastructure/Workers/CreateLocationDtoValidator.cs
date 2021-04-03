namespace TaskerAI.Infrastructure.Workers
{
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Dto;

    public class CreateLocationDtoValidator : BaseValidator<LocationDto>
    {
        public CreateLocationDtoValidator()
        {
            Required(p => p.Street);
            Required(p => p.Door);
            Required(p => p.ZipCode);
        }
    }
}
