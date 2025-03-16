using System;
using System.Threading.Tasks;
using Familestan.Infrastructure.Repositories;

namespace Familestan.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IMemberRepository Members { get; }
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        ILikeRepository Likes { get; }
        IFollowRepository Follows { get; }
        IFamilyRelationRepository FamilyRelations { get; }
        ILogRepository Logs { get; }
        ITagRepository Tags { get; }
        IPostTagRepository PostTags { get; }
        IPostWordRepository PostWords { get; }

        Task<int> CompleteAsync();
    }
}
