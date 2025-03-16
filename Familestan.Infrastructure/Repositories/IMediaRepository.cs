using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IMediaRepository : IBaseRepository<Media>
    {
        Task<IEnumerable<Media>> GetMediaByPostIdAsync(long postId);
    }
}
