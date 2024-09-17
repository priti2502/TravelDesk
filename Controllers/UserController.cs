using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .Where(u => u.Role.RoleName != "Admin" && u.IsActive)
                .ToListAsync();

            return Ok(users);
        }

        [HttpPost("users")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return BadRequest(new { message = "Email is already in use." });
            }

            if (await _context.Users.AnyAsync(u => u.MobileNum == user.MobileNum))
            {
                return BadRequest(new { message = "Mobile number is already in use." });
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("User ID mismatch.");
            }

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }
            if (user.Email != existingUser.Email)
            {
                if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                {
                    return BadRequest(new { message = "Email is already in use." });
                }
            }

            if (user.MobileNum != existingUser.MobileNum)
            {
                if (await _context.Users.AnyAsync(u => u.MobileNum == user.MobileNum))
                {
                    return BadRequest(new { message = "Mobile number is already in use." });
                }
            }




            // Update the properties
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Address = user.Address;
            existingUser.Password = user.Password; // Consider hashing passwords
           // existingUser.RoleId = user.RoleId;
           // existingUser.ManagerId = user.ManagerId;
           // existingUser.DepartmentId = user.DepartmentId;
            existingUser.ModifiedOn = DateTime.Now;

            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserId == id && x.IsActive);
            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("managers")]
        public async Task<IActionResult> GetManagers()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .Where(u => u.RoleId == 3)
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == email);
            return Ok(new { exists = userExists });
        }

        [HttpGet("check-mobile")]
        public async Task<IActionResult> CheckMobile([FromQuery] string mobileNum)
        {
            var userExists = await _context.Users.AnyAsync(u => u.MobileNum == mobileNum);
            return Ok(new { exists = userExists });
        }
    }
}
