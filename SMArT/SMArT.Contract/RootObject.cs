namespace SMArT.Contract
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RootObject
    {
        [JsonProperty("startAt")]
        public int StartAt { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("issues")]
        public List<Issue> Issues { get; set; }
    }
}