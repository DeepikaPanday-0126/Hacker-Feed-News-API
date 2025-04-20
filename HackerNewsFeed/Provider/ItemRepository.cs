using HackerNewsFeed.Contracts;
using HackerNewsFeed.Data;
using HackerNewsFeed.Models;
using Microsoft.EntityFrameworkCore;

namespace HackerNewsFeed.Provider
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Items>> GetItemsAsync()
        {
            try
            {
                return await _context.Items.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Items> GetItemAsync(int id)
        {
            try { 
                var items=_context.Items.FirstOrDefault(x=> x.Id == id);

            return await _context.Items.FindAsync(id) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Items> CreateItemAsync(Items item)
        {
            try { 
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Items> UpdateItemAsync(Items item)
        {
            try { 
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            try { 
            var item = await _context.Items.FindAsync(id);
            if (item == null)
                return false;

            _context.Items.Remove(item);
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

