using hotelfinder.Helpers;
using hotelfinder.Logic.Interfaces;
using hotelfinder.Models;
using hotelfinder.Rules;

namespace hotelfinder.Logic
{
    public class HotelFinderLogic : IHotelFinderLogic
    {
        private List<Hotel> _hotels = new List<Hotel>();

        public List<Hotel> GetHotels(List<Question> answers)
        {
            _hotels = new JsonHelper().LoadHotelsJson();
            List<Hotel> validHotels = new List<Hotel>();
            var hotelValidator = new HotelValidator(answers);

            foreach (Hotel hotel in _hotels)
            {
                bool isHotelValid = hotelValidator.ValidateHotel(hotel);

                if (isHotelValid)
                {
                    validHotels.Add(hotel);
                }
            }

            return validHotels;
        }
    }
}
