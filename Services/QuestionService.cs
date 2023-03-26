using hotelfinder.Helpers;
using hotelfinder.Models;
using hotelfinder.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hotelfinder.Services
{
    public class QuestionService : IQuestionService
    {
        private List<Question> _questions = new List<Question>();

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            _questions = new JsonHelper().LoadQuestionsJson();

            return _questions;
        }

        public async Task<Question> GetByNameAsync(string name)
        {
            return _questions.FirstOrDefault(x => x.Name == name);
        }
    }
}
