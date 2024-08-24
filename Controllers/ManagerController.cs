using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelDesk.Data;
using TravelDesk.DTO;
using TravelDesk.Models;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly TravelDeskContext _context;
        private readonly IConfiguration _configuration;

        public ManagerController(TravelDeskContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("employees-with-travel-requests")]
        public IActionResult GetEmployeesWithTravelRequests(int userId)
        {
            // Fetch all travel requests made by users managed by the given userId
            var requests = _context.TravelRequests
                .Include(r => r.User) // Ensure User entity is included
                .Include(r => r.Project) // Include Project entity if needed
                .Where(r => r.User.ManagerId == userId)
                .ToList();

            var employeeRequests = requests
                .GroupBy(r => r.User) // Group requests by user
                .Select(group => new
                {
                    User = new UserDto
                    {
                        UserId = group.Key.UserId,
                        FirstName = group.Key.FirstName,
                        LastName = group.Key.LastName,
                        Department = new DepartmentDto
                        {
                            DepartmentId = group.Key.Department.DepartmentId,
                            DepartmentName = group.Key.Department.DepartmentName
                        }
                    },
                    Requests = group.Select(r => new TravelRequestDto
                    {
                        TravelRequestId = r.TravelRequestId,
                        Project = new ProjectDto
                        {
                            ProjectId = r.Project.ProjectId,
                            ProjectName = r.Project.ProjectName
                        },
                        ReasonForTravel = r.ReasonForTravel,
                        FromDate = r.FromDate,
                        ToDate = r.ToDate,
                        FromLocation = r.FromLocation,
                        ToLocation = r.ToLocation,
                        Status = r.Status,
                        Comments = r.Comments
                    }).ToList()
                })
                .ToList();

            return Ok(new { employees = employeeRequests });
        }


        [HttpPost("requests/{id}/approve")]
        public async Task<IActionResult> ApproveRequest(int id, [FromBody] CommentDto commentDto)
        {
            var request = await _context.TravelRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = "Approved";
            request.Comments = commentDto.Comments;
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("requests/{id}/disapprove")]
        public async Task<IActionResult> DisapproveRequest(int id, [FromBody] CommentDto commentDto)
        {
            var request = await _context.TravelRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = "Disapproved";
            request.Comments = commentDto.Comments;
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("requests/{id}/return")]
        public async Task<IActionResult> ReturnRequest(int id, [FromBody] CommentDto commentDto)
        {
            var request = await _context.TravelRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = "Returned";
            request.Comments = commentDto.Comments;
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        

    }
}
