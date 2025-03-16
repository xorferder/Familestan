using Familestan.Core.Entities;
using Familestan.Infrastructure.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Familestan.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _unitOfWork.Posts.GetAllAsync();
        }

        public async Task<Post?> GetPostByIdAsync(long postId)
        {
            return await _unitOfWork.Posts.GetByIdAsync(postId);
        }

        public async Task AddPostAsync(Post post)
        {
            await _unitOfWork.Posts.AddAsync(post);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _unitOfWork.Posts.UpdateAsync(post);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeletePostAsync(long postId)
        {
            await _unitOfWork.Posts.SoftDeleteAsync(postId);
            await _unitOfWork.CompleteAsync();
        }
    }
}
