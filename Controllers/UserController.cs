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
                .Where(u=>u.Role.RoleName!="Admin" && u.IsActive==true)
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
        public IActionResult UpdateUser(int id, User updateUser)
        {
            if (id != updateUser.UserId)
            {
                return BadRequest();
            }

            var existingUser = _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefault(u => u.UserId == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update only specific fields
            existingUser.FirstName = updateUser.FirstName ?? existingUser.FirstName;
            existingUser.LastName = updateUser.LastName ?? existingUser.LastName;
            existingUser.Password = updateUser.Password ?? existingUser.Password;
            existingUser.Address = updateUser.Address ?? existingUser.Address;

            // Save changes
            _context.Entry(existingUser).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }



        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {

            var user = _context.Users.SingleOrDefault(x=>x.UserId==id && x.IsActive==true);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive= false; 
           
            _context.SaveChanges();
            return NoContent();
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

        //[HttpGet("current")]
        //// Assuming you want to restrict this endpoint to authorized users only
        //public async Task<ActionResult<User>> GetCurrentUser()
        //{
        //    // Assuming the user ID is available in the Claims of the authenticated user
        //    var userId = User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

        //    if (userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var user = await _context.Users
        //        .Include(u => u.Department)
        //        .Where(u => u.UserId == int.Parse(userId))
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // Optional: Select specific properties to return
        //    var userResponse = new
        //    {
        //        user.UserId,
        //        user.FirstName,
        //        user.LastName,
        //        DepartmentName = user.Department.DepartmentName
        //    };

        //    return Ok(userResponse);
        //}
    }
    }
