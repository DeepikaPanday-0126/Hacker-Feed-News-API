using HackerNewsFeed.Contracts;
using HackerNewsFeed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackerNewsFeed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
 
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            try { 
            return Ok(await _userRepository.GetUsersAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching users.",
                    error = ex.Message
                });
            }
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(string id)
        {
            try { 
            var user = await _userRepository.GetUserAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching users.",
                    error = ex.Message
                });
            }
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users user)
        {
            try { 
            var createdUser = await _userRepository.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while Adding users.",
                    error = ex.Message
                });
            }
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, Users user)
        {
            try { 
            if (id != user.Id)
                return BadRequest();

            var updatedUser = await _userRepository.UpdateUserAsync(user);
            if (updatedUser == null)
                return NotFound();

            return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating users.",
                    error = ex.Message
                });
            }
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try { 
            var success = await _userRepository.DeleteUserAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting users.",
                    error = ex.Message
                });
            }
        }
    }
}
   
