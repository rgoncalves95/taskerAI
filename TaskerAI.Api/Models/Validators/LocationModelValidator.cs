namespace TaskerAI.Api.Models.Validators
{
    using TaskerAI.Common;

    public class LocationModelValidator : BaseValidator<LocationModel>
    {
        public LocationModelValidator()
        {
            Required(p => p.Latitude);
            Required(p => p.Longitude);
            Required(p => p.Street);
            Required(p => p.Door);
            Required(p => p.ZipCode);
        }
    }
}
