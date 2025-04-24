using HackerNewsFeed.Constants;
using HackerNewsFeed.Models;
using Microsoft.EntityFrameworkCore;

namespace HackerNewsFeed.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Items> Items { get; set; }
        public DbSet<Users> Users { get; set; }

      
    }
}
