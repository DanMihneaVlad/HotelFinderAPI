using hotelfinder.Models;

namespace hotelfinder.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> GetByIdAsync(int id);
        Task<Question> PostAsync(Question question);
    }
}
