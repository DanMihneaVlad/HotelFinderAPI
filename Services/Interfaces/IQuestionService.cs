using hotelfinder.Models;

namespace hotelfinder.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> GetByNameAsync(string name);
    }
}
