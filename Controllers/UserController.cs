using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using TravelDesk.Data;
using TravelDesk.Models;


namespace TravekDesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly TravelDeskContext _context;

        private readonly IConfiguration _configuration;



        public UserController(TravelDeskContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .ToList();

            return Ok(users);
        }



        [HttpPost("users")]
        public ActionResult<User> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.UserId }, user);
        }

        [HttpPut("users/{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("managers")]
        public  IActionResult GetManagers()
        {
            var users = _context.Users
               .Include(u => u.Role)
               .Include(u => u.Department)
               .Include(u => u.Manager)
               .Where(u=>u.RoleId==3)
               .ToList();

            return Ok(users);

        }
    }
}
