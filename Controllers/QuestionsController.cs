using hotelfinder.Logic.Interfaces;
using hotelfinder.Models;
using hotelfinder.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hotelfinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IHotelFinderLogic _hotelFinderLogic;

        public QuestionsController(IQuestionService questionService, IHotelFinderLogic hotelFinderLogic)
        {
            _questionService = questionService;
            _hotelFinderLogic = hotelFinderLogic;
        }

        [HttpGet(Name = "GetQuestions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = await _questionService.GetAllAsync();
            return Ok(questions);
        }

        [HttpPost(Name = "GetHotels")]
        public async Task<ActionResult<List<Hotel>>> GetHotels([FromBody] List<Question> answers)
        {
            List<Hotel> hotels = _hotelFinderLogic.GetHotels(answers);
            
            return Ok(hotels);
        }
    }
}
