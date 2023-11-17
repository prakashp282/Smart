namespace SMArT.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Series
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("data")]
        public List<DataPoint> data { get; set; }

        [JsonProperty("colorByPoint")] 
        public bool colorByPoint { get; set; }
    }

    public class DataPoint
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("y")]
        public int y { get; set; }

        [JsonProperty("sliced")]
        public bool sliced { get; set; }

        [JsonProperty("selected")]
        public bool selected { get; set; }
    }

    public class ChartViewModel
    {
        [JsonProperty("series")]
        public List<Series> series { get; set; }
    }
}