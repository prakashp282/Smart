namespace SMArT.Contract
{
    using Newtonsoft.Json;

    public class Issuetype
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}