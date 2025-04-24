using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using HackerNewsFeed.Constants;
using System.ComponentModel.DataAnnotations;

namespace HackerNewsFeed.Models
{
    public class Items
    {
        [Required]
        public int Id { get; set; }
        public bool Deleted { get; set; }=false;
        [RegularExpression("^(job|story|comment|poll|pollopt)$", ErrorMessage = "Type must be one of: job, story, comment, poll, pollopt.")]
        public string Type { get; set; }

        public string? By { get; set; }
        
        public Int64 Time { get; set; }

        public string? Text { get; set; }

        public bool Dead { get; set; } = false;

        public Int64? Parent { get; set; }

        public int? Poll { get; set; }

        public int[]? Kids { get; set; }

        public string? URL { get; set; }
        public int? Score { get; set; }

        public string? Title { get; set; }

        public int[]? Parts { get; set; }
        
        public int? Descendants { get; set; }
      
    }
}
