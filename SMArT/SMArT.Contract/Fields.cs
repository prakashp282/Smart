namespace SMArT.Contract
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Fields
    {
        [JsonProperty("issuetype")]
        public Issuetype Issuetype { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("components")]
        public List<Component> Components { get; set; }

        [JsonProperty("customfield_19921")]
        public List<Customfield> Customfield { get; set; }
    }
}