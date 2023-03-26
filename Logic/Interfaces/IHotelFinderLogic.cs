using hotelfinder.Models;

namespace hotelfinder.Logic.Interfaces
{
    public interface IHotelFinderLogic
    {
        List<Hotel> GetHotels(List<Question> answers);
    }
}
