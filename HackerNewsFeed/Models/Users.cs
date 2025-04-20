using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HackerNewsFeed.Models
{
    public class Users
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Id { get; set; } = string.Empty;
        public Int64 Created { get; set; }
        public int Karma { get; set; }
        public string? About { get; set; }
        public Int64[]? Submitted { get; set; }
    }
}
