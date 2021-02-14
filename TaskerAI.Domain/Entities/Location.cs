using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain.Entities
{
    public class Location : BaseEntity
    {
        //TODO This should be removed
        internal static Location Create(int id)
            => new Location(id);

        //TODO This should be removed - used for mocking only
        internal static Location Create(string latitude, string longitude, int? id = null, string alias = null)
            => new Location(null, null, null, null, null, null, latitude, longitude, alias, null, id);

        internal static Location Create(string street,
                                        string number,
                                        string floor,
                                        string zipCode,
                                        string city,
                                        string country,
                                        string latitude,
                                        string longitude,
                                        string alias = null,
                                        string[] tags = null,
                                        int? id = null)
            => new Location(street, number, floor, zipCode, city, country, latitude, longitude, alias, tags, id);



        private Location(string street,
                         string door,
                         string floor,
                         string zipCode,
                         string city,
                         string country,
                         string latitude,
                         string longitude,
                         string alias = null,
                         string[] tags = null,
                         int? id = null)
        {
            this.Street = street;
            this.Door = door;
            this.Floor = floor;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Alias = alias;
            this.Tags = tags ?? Array.Empty<string>();
            this.Id = id;
        }

        //TODO This should be removed
        private Location(int id) => this.Id = id;

        public string Alias { get; private set; }
        public string Street { get; private set; }
        public string Door { get; private set; }
        public string Floor { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public IReadOnlyCollection<string> Tags { get; set; }

        protected override void IntegrityCheck() => throw new NotImplementedException();
    }
}