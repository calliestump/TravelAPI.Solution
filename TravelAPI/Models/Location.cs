using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TravelAPI.Models
{
  public class Location
  {
    public Location()
    {
      this.Reviews = new HashSet<LocationReview>();
    }
    public int LocationId { get; set; }
    [Required]
    [DisplayName("Enter a City")]
    public string City { get; set; }
    [Required]
    [DisplayName("Enter a Country")]
    public string Country { get; set; }
    public ICollection<LocationReview> Reviews { get; set; }
  }
}