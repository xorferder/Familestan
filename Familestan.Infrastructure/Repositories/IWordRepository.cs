using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IWordRepository : IBaseRepository<Word>
    {
        Task<Word?> GetByTextAsync(string wordText);
    }
}
