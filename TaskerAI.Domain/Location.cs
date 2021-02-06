using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Location : BaseEntity
    {
        internal static Location Create(int id) => new Location(id);

        private Location(string street, string number, string floor, string zipCode, string city, string country, double lat, double lon, int? id = null)
            : this(street, number, floor, zipCode, city, country, id)
        {
            this.Lat = lat;
            this.Lon = lon;
        }

        private Location(string street, string number, string floor, string zipCode, string city, string country, int? id = null)
            : this(id)
        {
            this.Street = street;
            this.Number = number;
            this.Floor = floor;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
        }

        private Location(int? id) => base.Id = id;

        public int Id { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Floor { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public double Lat { get; private set; }
        public double Lon { get; private set; }

        protected override void IntegrityCheck() => throw new NotImplementedException();
    }
}