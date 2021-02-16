namespace TaskerAI.Api.Models.Validators
{
    public class LocationModelValidator : BaseValidator<LocationModel>
    {
        public LocationModelValidator()
        {
            Required(p => p.Latitude);
            Required(p => p.Longitude);
            Required(p => p.Street);
            Required(p => p.Door);
            Required(p => p.ZipCode);
            Required(p => p.City);
            Required(p => p.Country);
        }
    }
}
