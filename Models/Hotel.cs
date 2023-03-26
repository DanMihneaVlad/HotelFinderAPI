using Newtonsoft.Json;

namespace hotelfinder.Models
{
    public class Hotel
    {
        [JsonProperty("nume")]
        public string Name { get; set; }
        [JsonProperty("tip_proprietate")]
        public string PropertyType { get; set; }
        [JsonProperty("capacitate")]
        public string Capacity { get; set; }
        [JsonProperty("stele")]
        public string Stars { get; set; }
        [JsonProperty("mic_dejun")]
        public string Breakfast { get; set; }
        [JsonProperty("facilitati")]
        public List<string> Facilities { get; set; }
        [JsonProperty("facilitati_camera")]
        public List<string> RoomFacilities { get; set; }
        [JsonProperty("baie")]
        public string PrivateBathroom { get; set; }
        [JsonProperty("scor")]
        public string Rating { get; set; }
        [JsonProperty("distanta_centru")]
        public string DistanceToCenter { get; set; }
    }
}
