using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        [DisplayName("Enter a Rating")]
        [Range(1, 5, ErrorMessage = "Rating must be on a 1-5 scale.")]
        public int Rating { get; set; }



        [Required]
        [DisplayName("Enter your username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Enter yuur password")]
        public string Password { get; set; }
        public string Token { get; set; }
        
    }
}