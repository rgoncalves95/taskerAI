namespace TaskerAI.Infrastructure.Dto
{
    public class LocationDto
    {
        public string Street { get; set; }
        public string Door { get; set; }
        public string Floor { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Alias { get; set; }
        public string[] Tags { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
