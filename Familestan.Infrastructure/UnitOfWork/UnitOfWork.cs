using Familestan.Infrastructure.Data;
using Familestan.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Familestan.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; }
        public IMemberRepository Members { get; }
        public IPostRepository Posts { get; }
        public ICommentRepository Comments { get; }
        public ILikeRepository Likes { get; }
        public IFollowRepository Follows { get; }
        public IFamilyRelationRepository FamilyRelations { get; }
        public ILogRepository Logs { get; }
        public ITagRepository Tags { get; }
        public IPostTagRepository PostTags { get; }
        public IPostWordRepository PostWords { get; }

        public UnitOfWork(ApplicationDbContext context,
            IUserRepository users,
            IMemberRepository members,
            IPostRepository posts,
            ICommentRepository comments,
            ILikeRepository likes,
            IFollowRepository follows,
            IFamilyRelationRepository familyRelations,
            ILogRepository logs,
            ITagRepository tags,
            IPostTagRepository postTags,
            IPostWordRepository postWords)
        {
            _context = context;
            Users = users;
            Members = members;
            Posts = posts;
            Comments = comments;
            Likes = likes;
            Follows = follows;
            FamilyRelations = familyRelations;
            Logs = logs;
            Tags = tags;
            PostTags = postTags;
            PostWords = postWords;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
