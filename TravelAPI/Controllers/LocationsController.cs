using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using TravelAPI.Services;
using TravelAPI.Entities;

namespace TravelAPI.Models
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    
    private TravelAPIContext _db;
    private IUserService _userService;
    public LocationsController(TravelAPIContext db)
    {
      _db =db;
    }
    
    // GET api/Reviews

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string username, string password, string city, string country)
    {
      var query = _db.Reviews.AsQueryable();
      if (username != null)
      {
        query = query.Where(entry => entry.Username == username);
      }
      if (password != null)
      {
        query = query.Where(entry => entry.Password == password);
      }
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
    // [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Location> Get(int id)
    {
      return _db.Reviews.FirstOrDefault(entry => entry.LocationId == id);
    }
    // PUT api/Locations/{id}

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Locaiton location)
    {
      location.LocationId = id;
      _db.Entry(location).State = EntityState.Modified;
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

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] Location location)
    {
      var user = _userService.Authenticate(location.Username, location.Password);


      if (user == null)
        return BadRequest(new { message = "Username or password is incorrect"});

      return Ok(user);  
    }

    [HttpGet]
      public IActionResult GetAll()
      {
          var users =  _userService.GetAll();
          return Ok(users);
      }
  }
}