using System.Collections.Generic;

namespace TravelAPI.Models
{
    public class Location
    {
      public Location()
      {
        this.JoinTables = new HashSet<AttractionLocation>();
      }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Country { get; set; }
        public string Rating { get; set; }

    public ICollection<AttractionLocation> JoinTables { get; set; }
    }
}