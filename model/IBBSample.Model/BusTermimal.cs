using Newtonsoft.Json;

namespace IBBSample.Model
{
    public class BusTermimal
    {
        public int ID { get; set; }
        [JsonProperty("GARAJ_ADI")]
        public string Name { get; set; }
        [JsonProperty("GARAJ_KODU")]
        public string Code { get; set; }
        [JsonProperty("KOORDINAT")]
        public string Coordinate { get; set; }
    }
}