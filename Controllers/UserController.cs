using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TravelDesk.Data;
using TravelDesk.Models;

namespace TravelDesk.Controllers
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
                .Where(u => u.Role.RoleName != "Admin" && u.IsActive == true)
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
                return BadRequest("User ID mismatch.");
            }

            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }
            // Update the properties
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Address = user.Address;
            existingUser.Password = user.Password;
          //  existingUser.RoleId = user.RoleId;
           // existingUser.ManagerId = user.ManagerId;
            //existingUser.DepartmentId = user.DepartmentId;
            existingUser.ModifiedOn = DateTime.Now; // Ensure modified timestamp is updated

            _context.Entry(existingUser).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }




        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == id && x.IsActive == true);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = false;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("users/{userId}")]
        public ActionResult<User> GetUserById(int userId)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefault(u => u.UserId == userId && u.IsActive == true);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("managers")]
        public IActionResult GetManagers()
        {
            var users = _context.Users
               .Include(u => u.Role)
               .Include(u => u.Department)
               .Include(u => u.Manager)
               .Where(u => u.RoleId == 3)
               .ToList();

            return Ok(users);
        }
    }
}
