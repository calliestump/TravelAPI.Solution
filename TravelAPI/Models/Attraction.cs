using System.Collections.Generic;

namespace TravelAPI.Models
{
    public class Attraction
    {
      public Attraction()
      {
        this.JoinTables = new HashSet<AttractionLocation>();
      }
        public int AttractionId { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public virtual ICollection<AttractionLocation> JoinTables { get; set; }
    }
}