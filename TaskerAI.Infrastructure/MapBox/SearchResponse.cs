namespace TaskerAI.Infrastructure.MapBox
{
    using System.Text.Json.Serialization;

    public class SearchResponse
    {
        [JsonPropertyName("features")]
        public Feature[] Features { get; set; }
    }

    public class Feature
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("place_type")]
        public string[] PlaceType { get; set; }

        [JsonPropertyName("relevance")]
        public float Relevance { get; set; }

        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("place_name")]
        public string PlaceName { get; set; }

        [JsonPropertyName("center")]
        public float[] Center { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("context")]
        public Context[] Context { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("foursquare")]
        public string Foursquare { get; set; }

        [JsonPropertyName("landmark")]
        public bool Landmark { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("coordinates")]
        public float[] Coordinates { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Context
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("wikidata")]
        public string Wikidata { get; set; }

        [JsonPropertyName("short_code")]
        public string ShortCode { get; set; }
    }
}
