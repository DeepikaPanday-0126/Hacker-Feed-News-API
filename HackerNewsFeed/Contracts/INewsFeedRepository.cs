using HackerNewsFeed.Models;

namespace HackerNewsFeed.Contracts
{
    public interface INewsFeedRepository
    {
        Task<Items> GetLatestItem();
        Task<Items> GetItemByIdAsync(int id);
        Task<List<Items>> GetTopStories();
        Task<List<Items>> GetTopAskedStories();
      
    }
}
