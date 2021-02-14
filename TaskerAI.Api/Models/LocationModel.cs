namespace TaskerAI.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class LocationModel
    {
        public LocationModel() => this.Tags = Array.Empty<string>();

        public int? Id { get; internal set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Street { get; set; }
        public string Door { get; set; }
        public string Floor { get; set; }
        public string Zip { get; set; }
        public string Alias { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}