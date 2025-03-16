using Familestan.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Familestan.Infrastructure.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member?> GetMemberByIdAsync(long memberId);
        Task AddMemberAsync(Member member);
        Task UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(long memberId);
    }
}
