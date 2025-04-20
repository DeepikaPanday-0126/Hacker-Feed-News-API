using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HackerNewsFeed.Models
{
    public class Users
    {

        [Required(ErrorMessage = "Name is required.")]
        public string id { get; set; } = string.Empty;
        public Int64 created { get; set; }
        public int karma { get; set; }
        public string? about { get; set; }
        public Int64[]? submitted { get; set; }
    }
}
