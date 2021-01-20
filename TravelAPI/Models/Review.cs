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
        [DisplayName("Enter a Description")]
        [StringLength(50, ErrorMessage = "Description must be at least 50 characters")]
        public string Description { get; set; }
    }
}