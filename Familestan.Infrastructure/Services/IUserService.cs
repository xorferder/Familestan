using Familestan.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Familestan.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(long userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(long userId);
    }
}
