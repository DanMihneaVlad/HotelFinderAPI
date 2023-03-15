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

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet(Name = "GetQuestions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = await _questionService.GetAllAsync();
            return Ok(questions);
        }

        [HttpPost(Name = "CreateQuestion")]
        public async Task<ActionResult<Question>> CreateQuestion([FromBody] Question question)
        {
            var addedQuestion = await _questionService.PostAsync(question);
            return Ok(addedQuestion);
        }
    }
}
