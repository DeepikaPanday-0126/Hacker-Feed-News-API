using HackerNewsFeed.Contracts;
using HackerNewsFeed.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsFeed.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
   
    public class NewsFeedController : Controller
    {
        private readonly INewsFeedRepository _itemRepository;

        public NewsFeedController(INewsFeedRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<Items>> GetLatestItem()
        {
            try { 
            return Ok(await _itemRepository.GetLatestItem());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching Item.",
                    error = ex.Message
                });
            }
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Items>> GetItemByIdAsync(int id)
        {
            try { 
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching Item.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("top-stories")]
        public async Task<ActionResult<Items>> GetTopStories()
        {
            try
            {
                return Ok(await _itemRepository.GetTopStories());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching Item.",
                    error = ex.Message
                });
            }
        }
        [HttpGet("asked-stories")]
        public async Task<ActionResult<Items>> GetTopAskedStories()
        {
            try
            {
                return Ok(await _itemRepository.GetTopAskedStories());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching Item.",
                    error = ex.Message
                });
            }
        }
    }
}
