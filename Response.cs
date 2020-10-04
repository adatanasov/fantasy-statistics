using Newtonsoft.Json;

namespace fantasy_statistics
{
    public class Response
    {
        [JsonProperty("elements")]
        public Player[] Players { get; set; }
    }
}