using Newtonsoft.Json;

namespace hotelfinder.Models
{
    public class Question
    {
        [JsonProperty("nume")]
        public string Name { get; set; }
        [JsonProperty("intrebare")]
        public string QuestionText { get; set; }
        [JsonProperty("raspunsuri")]
        public List<string> Answers { get; set; }
    }
}
