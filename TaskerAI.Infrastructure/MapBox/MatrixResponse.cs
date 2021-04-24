namespace TaskerAI.Infrastructure.MapBox
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json.Serialization;

    public class MatrixResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("distances")]
        public float[][] Distances { get; set; }

        [JsonPropertyName("durations")]
        public float[][] Durations { get; set; }

        [JsonPropertyName("destinations")]
        public Waypoint[] Destinations { get; set; }

        [JsonPropertyName("sources")]
        public Waypoint[] Sources { get; set; }
    }

    public class Waypoint
    {
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public float[] Location { get; set; }
    }
}
