using hotelfinder.Models;
using Newtonsoft.Json;

namespace hotelfinder.Helpers
{
    public class JsonHelper
    {
        public List<Question> LoadQuestionsJson()
        {
            using (StreamReader r = new StreamReader("baza.json"))
            {
                string json = r.ReadToEnd();
                List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(json);

                if (questions != null)
                {
                    return questions;
                }
                else
                {
                    return new List<Question>();
                }
            }
        }

        public List<Hotel> LoadHotelsJson()
        {
            using (StreamReader r = new StreamReader("accomodation.json"))
            {
                string json = r.ReadToEnd();
                List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);

                if (hotels != null)
                {
                    return hotels;
                }
                else
                {
                    return new List<Hotel>();
                }
            }
        }
    }
}
