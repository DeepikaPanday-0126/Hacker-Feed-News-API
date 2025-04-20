using HackerNewsFeed.Contracts;
using HackerNewsFeed.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsFeed.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
   
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Items>>> GetItems()
        {
            try { 
            return Ok(await _itemRepository.GetItemsAsync());
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
        public async Task<ActionResult<Items>> GetItem(int id)
        {
            try { 
            var item = await _itemRepository.GetItemAsync(id);
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

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<Items>> CreateItem(Items item)
        {
            try { 
            var createdItem = await _itemRepository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while Adding Item.",
                    error = ex.Message
                });
            }
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, Items item)
        {
            try { 
            if (id != item.Id)
                return BadRequest();

            var updatedItem = await _itemRepository.UpdateItemAsync(item);
            if (updatedItem == null)
                return NotFound();

            return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating Item.",
                    error = ex.Message
                });
            }
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try { 
            var success = await _itemRepository.DeleteItemAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting Item.",
                    error = ex.Message
                });
            }
        }
    }
}
