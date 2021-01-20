using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TravelAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    private TravelAPIContext _db;
    public LocationsController(TravelAPIContext db)
    {
      _db = db;
    }

    // GET api/Locations
    [HttpGet]
    public ActionResult<IEnumerable<Location>> Get(string country, string city)
    {
      var query = _db.Locations.AsQueryable();
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }
      return query.ToList();
    }
    // POST api/Locations
    [HttpPost]
    public void Post([FromBody] Location location)
    {
      _db.Locations.Add(location);
      _db.SaveChanges();
    }

    // GET api/Locations/{id}
    [HttpGet("{id}")]
    public ActionResult<Location> Get(int id)
    {
      return _db.Locations.FirstOrDefault(entry => entry.LocationId == id);
    }

    // PUT api/Locations/{id}
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Location location)
    {
      location.LocationId = id;
      _db.Entry(location).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // POST api/Locations/{id}
    [HttpPost("{LocationId}")]
    public void AddReview(int LocationId, int ReviewId)
    {
      Console.WriteLine(ReviewId);
      if (ReviewId != 0)
      {
        _db.LocationReview.Add(new LocationReview() { ReviewId = ReviewId, LocationId = LocationId });
      }
      _db.SaveChanges();
    }

    // DELETE api/Location/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var LocationToDelete = _db.Locations.FirstOrDefault(entry => entry.LocationId == id);
      _db.Locations.Remove(LocationToDelete);
      _db.SaveChanges();
    }
  }
}
