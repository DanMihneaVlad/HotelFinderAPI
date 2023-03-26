using hotelfinder.Helpers;
using hotelfinder.Logic.Interfaces;
using hotelfinder.Models;

namespace hotelfinder.Logic
{
    public class HotelFinderLogic : IHotelFinderLogic
    {
        private List<Hotel> _hotels = new List<Hotel>();

        public List<Hotel> GetHotels(List<Question> answers)
        {
            _hotels = new JsonHelper().LoadHotelsJson();

            return _hotels;
        }
    }
}
