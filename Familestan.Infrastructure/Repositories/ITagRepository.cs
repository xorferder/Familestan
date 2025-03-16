using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<Tag?> GetByNameAsync(string tagName);
    }
}
