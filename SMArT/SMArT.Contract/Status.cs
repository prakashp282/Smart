namespace SMArT.Contract
{
    using Newtonsoft.Json;

    public class Status
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FixVersion
    {
        public string name { get; set; }
    }

    public class Component
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Customfield
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}