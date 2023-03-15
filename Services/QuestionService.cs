using hotelfinder.Models;
using hotelfinder.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hotelfinder.Services
{
    public class QuestionService : IQuestionService
    {
        private List<Question> _questions = new List<Question>
        {
            new Question
            {
                Id = 1,
                QuestionText = "Reservation type",
                Answers = new List<string>
                {
                    "Hotel",
                    "Hostel",
                    "Apartment"
                }
            },
            new Question
            {
                Id = 2,
                QuestionText = "Private bathroom",
                Answers= new List<string>
                {
                    "Yes",
                    "No"
                }
            }
        };

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return _questions;
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return _questions.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Question> PostAsync(Question question)
        {
            _questions.Add(question);
            return question;
        }
    }
}
