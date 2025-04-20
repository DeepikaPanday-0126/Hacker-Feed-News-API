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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>().HasData(
                new Items
                {
                    Id = 1,
                    Deleted = false,
                    Type = "Story",
                    By = "JJ",
                    Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    Text = "Testing an items.",
                    Dead = false,
                    Parent = null,
                    Poll = 0,
                    Kids = new[] { 2, 3 },
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 120,
                    Title = "Software Developer",
                    Parts = new[] { 101, 102 },
                    Descendants = 12
                },
                new Items
                {
                    Id = 2,
                    Deleted = false,
                    Type = "Comment",
                    By = "bob",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-30).ToUnixTimeSeconds(),
                    Text = "Good",
                    Dead = false,
                    Parent = "1",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = null,
                    Score = 15,
                    Title = "",
                    Parts = Array.Empty<int>(),
                    Descendants = 90
                },
                new Items
                {
                    Id = 3,
                    Deleted = false,
                    Type = "Story",
                    By = "Tom",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-25).ToUnixTimeSeconds(),
                    Text = "Animals Story",
                    Dead = false,
                    Parent = "1",
                    Poll = 0,
                    Kids = new[] { 4 },
                    URL = null,
                    Score = 10,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 56
                },
                new Items
                {
                    Id = 4,
                    Deleted = false,
                    Type = "Comment",
                    By = "Jerry",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants =34
                },
                new Items
                {
                    Id = 5,
                    Deleted = false,
                    Type = "Comment",
                    By = "abc",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 34
                },
                new Items
                {
                    Id = 6,
                    Deleted = false,
                    Type = "comment",
                    By = "def",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 34
                },
                new Items
                {
                    Id = 7,
                    Deleted = false,
                    Type = "comment",
                    By = "ghi",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 34
                },
                new Items
                {
                    Id = 8,
                    Deleted = false,
                    Type = "comment",
                    By = "jkl",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 34
                },
                new Items
                {
                    Id = 9,
                    Deleted = false,
                    Type = "comment",
                    By = "xyz",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 34
                },
                new Items
                {
                    Id = 10,
                    Deleted = false,
                    Type = "comment",
                    By = "hjk",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 34
                },
                new Items
                {
                    Id = 11,
                    Deleted = false,
                    Type = "comment",
                    By = "iop",
                    Time = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                    Text = "Got it",
                    Dead = false,
                    Parent = "3",
                    Poll = 0,
                    Kids = Array.Empty<int>(),
                    URL = "http://www.getdropbox.com/u/2/screencast.html",
                    Score = 5,
                    Title = null,
                    Parts = Array.Empty<int>(),
                    Descendants = 34
                }
            );
            modelBuilder.Entity<Users>().HasData(
               new Users
               {
                   id = "JJ",
                   created = DateTimeOffset.UtcNow.AddYears(-2).ToUnixTimeSeconds(),
                   karma = 100,
                   about = "Senior developer",
                   submitted = [7699907, 7637962, 7596179, 7596163, 7594569]
               },
               new Users
               {
                   id = "Bob",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 500,
                   about = "Technology Developer.",
                   submitted = [8168423, 8090946, 8090326, 7699990]
               },
               new Users
               {
                   id = "Tom",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 234,
                   about = "Technology Specialist.",
                   submitted = [6225810, 6111999, 5580079, 5112008, 4907948]
               },
               new Users
               {
                   id = "Jerry",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 667,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "abc",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 456,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "def",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma =789 ,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "jkl",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 234,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "iu",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 789,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "bvc",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma =89 ,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "hytg",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 56,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "uiop",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 90,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "sdf",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 890,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "mnb",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 123,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               },
               new Users
               {
                   id = "xcv",
                   created = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds(),
                   karma = 67,
                   about = "Technology Analyst.",
                   submitted = [9128264, 9127792, 9129248,]
               }
            );
        }

    }
}
