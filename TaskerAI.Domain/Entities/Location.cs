namespace TaskerAI.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Location : BaseEntity
    {
        private readonly List<string> aliases;
        private readonly List<string> tags;

        //TODO This should be removed
        internal static Location Create(int id) => new Location(id);

        //TODO This should be removed - used for mocking only
        internal static Location Create(string latitude, string longitude, int? id = null, string alias = null)
            => new Location(null, null, null, null, null, null, latitude, longitude, (alias != null ? new[] { alias } : null), null, id);

        internal static Location Create(string street,
                                        string number,
                                        string floor,
                                        string zipCode,
                                        string city,
                                        string country,
                                        string latitude,
                                        string longitude,
                                        string alias = null,
                                        IEnumerable<string> tags = null,
                                        int? id = null)
            => new Location(street, number, floor, zipCode, city, country, latitude, longitude, (alias != null ? new[] { alias } : null), tags, id);

        internal static Location Create(string street,
                                        string number,
                                        string floor,
                                        string zipCode,
                                        string city,
                                        string country,
                                        string latitude,
                                        string longitude,
                                        IEnumerable<string> alias = null,
                                        IEnumerable<string> tags = null,
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
                         IEnumerable<string> aliases = null,
                         IEnumerable<string> tags = null,
                         int? id = null)
        {
            this.aliases = aliases?.ToList() ?? new List<string>();
            this.tags = tags?.ToList() ?? new List<string>();

            this.Street = street;
            this.Door = door;
            this.Floor = floor;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Id = id;
        }

        //TODO This should be removed
        private Location(int id) => this.Id = id;

        public string Street { get; private set; }
        public string Door { get; private set; }
        public string Floor { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public IEnumerable<string> Aliases => this.aliases;
        public IEnumerable<string> Tags => this.tags;

        protected override void IntegrityCheck() => throw new NotImplementedException();

        public void AddAliases(params string[] alias)
        {
            string[] @new = alias.Except(this.aliases, StringComparer.OrdinalIgnoreCase).ToArray();
            if (@new.Any())
            {
                this.aliases.AddRange(@new);
            }
        }

        public void AddTags(params string[] tags)
        {
            string[] @new = tags.Except(this.tags, StringComparer.OrdinalIgnoreCase).ToArray();
            if (@new.Any())
            {
                this.tags.AddRange(@new);
            }
        }
    }
}