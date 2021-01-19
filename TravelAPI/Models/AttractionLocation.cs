namespace TravelAPI.Models
{
  public class AttractionLocation
    {       
        public int AttractionLocationId { get; set; }
        public int LocationId { get; set; }
        public int AttractionId { get; set; }
        public Location Location { get; set; }
        public Attraction Attraction { get; set; }
    }
}