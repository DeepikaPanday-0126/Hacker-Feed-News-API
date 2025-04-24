using System.Runtime;
using System.Text.Json;
using HackerNewsFeed.Contracts;
using HackerNewsFeed.Data;
using HackerNewsFeed.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace HackerNewsFeed.Provider
{
    public class NewsFeedRepository : INewsFeedRepository
    {
        private readonly IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;        
        private  string CacheKey = "NewsFeeds";        
        private readonly GitHubAPISetting _settings;
        private readonly string apiUrl ="https://hacker-news.firebaseio.com/v0/";

        public NewsFeedRepository(IMemoryCache cache, IHttpClientFactory httpClientFactory, IOptions<GitHubAPISetting> options)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
            _settings = options.Value;
            
        }
        public string GetUrl() => _settings.ApiUrl;

        public async Task<Items> GetLatestItem()
        {

         
            if (string.IsNullOrEmpty(apiUrl))
                return null;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Latest-Stories", "HackersNewsFeed");

            var response = await client.GetAsync(apiUrl + "maxitem.json");
            if (!response.IsSuccessStatusCode) return null;

            var itemId = int.Parse(await response.Content.ReadAsStringAsync());

            return await GetItemByIdAsync(itemId);
        }

        public async Task<Items> GetItemByIdAsync(int id)
        {

            this.CacheKey = id.ToString();
            if (_cache.TryGetValue(CacheKey, out Items cachedResponse))
            {
                return cachedResponse;
            }
          
            if (string.IsNullOrEmpty(apiUrl))
                return null;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Items-by-id", "HackersNewsFeed");

            var response = await client.GetAsync(apiUrl+ "item/" +id+ ".json");
            if (!response.IsSuccessStatusCode) return null;

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var responseData = JsonSerializer.Deserialize<Items>(jsonResponse, options);

            _cache.Set(CacheKey, responseData, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });

            return responseData;
        }
        public async Task<List<Items>> GetTopStories()     
        {

            if (string.IsNullOrEmpty(apiUrl))
                return null;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Top-Stories", "HackersNewsFeed");

            var response = await client.GetAsync(apiUrl + "topstories.json");
            if (!response.IsSuccessStatusCode)
                return new List<Items>();

            // Step 1: Get array of item IDs from Git URL
            var json = await response.Content.ReadAsStringAsync();
            var itemIds = JsonSerializer.Deserialize<List<int>>(json);

            if (itemIds == null || !itemIds.Any())
                return new List<Items>();

            // Step 2: Fetch full Item details for each ID
            var tasks = itemIds.Select(id => GetItemByIdAsync(id));
            var items = await Task.WhenAll(tasks);

            // Step 3: Filter out nulls (if any ID was invalid)
            return items.Where(i => i != null).ToList();
        }

        public async Task<List<Items>> GetTopAskedStories()
        {
          
            if (string.IsNullOrEmpty(apiUrl))
                return null;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Top-Stories", "HackersNewsFeed");

            var response = await client.GetAsync(apiUrl + "askstories.json");
            if (!response.IsSuccessStatusCode)
                return new List<Items>();

            // Step 1: Get array of item IDs from Git URL
            var json = await response.Content.ReadAsStringAsync();
            var itemIds = JsonSerializer.Deserialize<List<int>>(json);

            if (itemIds == null || !itemIds.Any())
                return new List<Items>();

            // Step 2: Fetch full Item details for each ID
            var tasks = itemIds.Select(id => GetItemByIdAsync(id));
            var items = await Task.WhenAll(tasks);

            // Step 3: Filter out nulls (if any ID was invalid)
            return items.Where(i => i != null).ToList();
        }
    }
}

