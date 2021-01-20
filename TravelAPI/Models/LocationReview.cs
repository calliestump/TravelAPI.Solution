namespace TravelAPI.Models
{
  public class LocationReview
  {
    public int LocationReviewId { get; set; }
    public int LocationId { get; set; }
    public int ReviewId { get; set; }
    public Location Location { get; set; }
    public Review Review { get; set; }
  }
}