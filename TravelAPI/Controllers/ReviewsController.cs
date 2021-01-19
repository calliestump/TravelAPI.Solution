using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using TravelAPI.Services;

namespace TravelAPI.Models
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private TravelAPIContext _db;
    public ReviewsController(TravelAPIContext db)
    {
      _db =db;
    }
    private IUserService _userService;

    public ReviewsController(IUserService userService)
    {
        _userService = userService;
    }
    // GET api/Reviews
    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string city, string country, int rating)
    {
      var query = _db.Reviews.AsQueryable();
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }
      if (rating != 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return query.ToList();
    }
    // POST api/Reviews
    [HttpPost]
    public void Post([FromBody] Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
    }
    // GET api/Reviews/{id}
    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id)
    {
      return _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
    }
    // Starts authentication for PUT & DELETE
    [Authorize]
    [AllowAnonymous]
    [HttpPost("api/authenticate")]
    public IActionResult Authenticate([FromBody]Review userParam)
    {
        var user = _userService.Authenticate(userParam.Username, userParam.Password);

        if (user == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users =  _userService.GetAll();
        return Ok(users);
        }
    // PUT api/Reviews/{id}
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
      review.ReviewId = id;
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
    }
    // DELETE api/Reviews/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var ReviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      _db.Reviews.Remove(ReviewToDelete);
      _db.SaveChanges();
    }
  }
}