using HackerNewsFeed.Models;

namespace HackerNewsFeed.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<Users> GetUserAsync(string id);
        Task<Users> CreateUserAsync(Users user);
        Task<Users> UpdateUserAsync(Users user);
        Task<bool> DeleteUserAsync(string id);
    }
}
