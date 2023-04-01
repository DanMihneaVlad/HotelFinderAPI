using hotelfinder.Models;

namespace hotelfinder.Rules
{
    public class HotelValidator
    {
        private List<Question> _answers;

        public HotelValidator(List<Question> answers)
        {
            _answers = answers;
        }

        private readonly List<IValidationRule> _rules = new List<IValidationRule>
        {
            new ValidateTypeRule(),
            new ValidateCapacityRule(),
            new ValidateStarsRule(),
            new ValidateBreakfastRule(),
            new ValidateBathroomRule(),
            new ValidateDistanceToCenterRule(),
            new ValidateRatingRule(),
            new ValidateFacilitiesRule(),
            new ValidateRoomFacilitiesRule(),
        };

        public bool ValidateHotel(Hotel hotel)
        {
            foreach (var rule in _rules)
            {
                if (!rule.Validate(_answers, hotel))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public interface IValidationRule
    {
        bool Validate(List<Question> answers, Hotel hotel);
    }

    public class ValidateTypeRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where(a => a.Name.Trim() == "tip_proprietate").Select(a => a.Answers.First()).First();

            if (hotel.PropertyType.Trim() != answer.Trim())
            {
                return false;
            }
            return true;
        }
    }

    public class ValidateCapacityRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where(a => a.Name.Trim() == "capacitate").Select(a => a.Answers.First()).First();
            int capacity = Int32.Parse(answer.Trim());
            int hotelCapacity = Int32.Parse(hotel.Capacity);

            if (capacity > hotelCapacity)
            {
                return false;
            }
            return true;
        }
    }

    public class ValidateStarsRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where(a => a.Name.Trim() == "stele").Select(a => a.Answers.First()).First();

            try
            {
                int starCount = Int32.Parse(answer.Trim());
                int hotelStarCount = Int32.Parse(hotel.Stars.Trim());

                if (starCount > hotelStarCount)
                {
                    return false;
                }
                return true;
            }
            catch (FormatException e)
            {
                return true;
            }
        }
    }

    public class ValidateBreakfastRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where((a) => a.Name.Trim() == "mic_dejun").Select(a => a.Answers.First()).First();

            if (answer.Trim() == "nu")
            {
                return true;
            }
            else
            {
                if (answer.Trim() == hotel.Breakfast.Trim())
                {
                    return true;
                }
                return false;
            }
        }
    }

    public class ValidateBathroomRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where((a) => a.Name.Trim() == "baie").Select(a => a.Answers.First()).First();

            if (answer.Trim() == "nu")
            {
                return true;
            }
            else
            {
                if (answer.Trim() == hotel.PrivateBathroom.Trim())
                {
                    return true;
                }
                return false;
            }
        }
    }

    public class ValidateDistanceToCenterRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where((a) => a.Name.Trim() == "distanta_centru").Select(a => a.Answers.First()).First();

            if (answer.Trim() == "Nu mă interesează")
            {
                return true;
            }
            else
            {
                if (answer.Trim() == hotel.DistanceToCenter.Trim())
                {
                    return true;
                }
                return false;
            }
        }
    }

    public class ValidateRatingRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where((a) => a.Name.Trim() == "scor").Select(a => a.Answers.First()).First();

            if (answer.Trim() == "Nu mă interesează")
            {
                return true;
            }
            else
            {
                var hotelRating = hotel.Rating.Trim();

                if (answer.Trim() == hotelRating.Trim())
                {
                    return true;
                }

                if (answer.Trim().Contains('6'))
                {
                    return true;
                }

                if (answer.Trim().Contains('7'))
                {
                    if (hotelRating.Trim().Contains('6'))
                    {
                        return false;
                    }
                    return true;
                }

                if (answer.Trim().Contains('8'))
                {
                    if (hotelRating.Trim().Contains('6') || hotelRating.Trim().Contains('7'))
                    {
                        return false;
                    }
                    return true;
                }

                if (answer.Trim().Contains('9'))
                {
                    if (hotelRating.Trim().Contains('6') || hotelRating.Trim().Contains('7') || hotelRating.Trim().Contains('8'))
                    {
                        return false;
                    }
                    return true;
                }

                return true;
            }
        }
    }

    public class ValidateFacilitiesRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where((a) => a.Name.Trim() == "facilitati").Select(a => a.Answers).First();
            
            foreach(var facility in answer)
            {
                if (!hotel.Facilities.Contains(facility.Trim()))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class ValidateRoomFacilitiesRule : IValidationRule
    {
        public bool Validate(List<Question> answers, Hotel hotel)
        {
            var answer = answers.Where((a) => a.Name.Trim() == "facilitati_camera").Select(a => a.Answers).First();

            foreach (var facility in answer)
            {
                if (!hotel.RoomFacilities.Contains(facility.Trim()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
