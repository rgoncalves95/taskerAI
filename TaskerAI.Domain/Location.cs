using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Location : BaseEntity
    {
        internal static Location Create(int id)
        {
            return new Location(id);
        }

        private Location(string street, string number, string floor, string zipCode, string city, string country, double lat, double lon)
            : this(street, number, floor, zipCode, city, country)
        {
            this.Lat = lat;
            this.Lon = lon;
        }

        private Location(string street, string number, string floor, string zipCode, string city, string country)
        {
            this.Street = street;
            this.Number = number;
            this.Floor = floor;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
        }

        private Location(int id)
        {
            this.Id = id;
        }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Floor { get; private set; }

        public string ZipCode { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        public double Lat { get; private set; }

        public double Lon { get; private set; }

        internal void CalculateGeoCoordinates()
        {
            //this method will be called if the coordinates are not calculated in the client side - 
        }

        protected override void IntegrityCheck() => throw new System.NotImplementedException();
    }
}