using Familestan.Core.Entities;
using Familestan.Infrastructure.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Familestan.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _unitOfWork.Members.GetAllAsync();
        }

        public async Task<Member?> GetMemberByIdAsync(long memberId)
        {
            return await _unitOfWork.Members.GetByIdAsync(memberId);
        }

        public async Task AddMemberAsync(Member member)
        {
            await _unitOfWork.Members.AddAsync(member);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateMemberAsync(Member member)
        {
            await _unitOfWork.Members.UpdateAsync(member);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteMemberAsync(long memberId)
        {
            await _unitOfWork.Members.SoftDeleteAsync(memberId);
            await _unitOfWork.CompleteAsync();
        }
    }
}
