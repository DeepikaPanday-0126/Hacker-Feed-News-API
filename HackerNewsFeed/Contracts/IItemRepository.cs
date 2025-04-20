using HackerNewsFeed.Models;

namespace HackerNewsFeed.Contracts
{
    public interface IItemRepository
    {
        Task<IEnumerable<Items>> GetItemsAsync();
        Task<Items> GetItemAsync(int id);
        Task<Items> CreateItemAsync(Items item);
        Task<Items> UpdateItemAsync(Items item);
        Task<bool> DeleteItemAsync(int id);
    }
}
