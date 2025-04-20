using HackerNewsFeed.Contracts;
using HackerNewsFeed.Data;
using HackerNewsFeed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackerNewsFeed.Provider
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            try { 
            return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> GetUserAsync(string id)
        {
            try { 
            return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> CreateUserAsync(Users user)
        {
            try { 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> UpdateUserAsync(Users user)
        {
            try { 
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            try { 
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}

