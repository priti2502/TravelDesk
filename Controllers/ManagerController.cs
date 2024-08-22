using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Data;
using TravelDesk.DTO;
using TravelDesk.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ManagerController : ControllerBase
    {
        private readonly TravelDeskContext _context;

        public ManagerController(TravelDeskContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardDto>> GetDashboard()
        {
            var managerId = GetCurrentManagerId(); // Implement this method to get current manager's ID
            var requests = await _context.TravelRequests
                .Where(r => r.User.ManagerId == managerId && r.IsActive)
                .Include(r => r.User)
                .Include(r => r.Project)
                .Select(r => new TravelRequestDto
                {
                    TravelRequestId = r.TravelRequestId,
                    User = new UserDto
                    {
                        UserId = r.User.UserId,
                        FirstName = r.User.FirstName,
                        LastName = r.User.LastName,
                        Department = new DepartmentDto
                        {
                            DepartmentId = r.User.Department.DepartmentId,
                            DepartmentName = r.User.Department.DepartmentName
                        }
                    },
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
                })
                .ToListAsync();

            var dashboard = new DashboardDto
            {
                Requests = requests
            };

            return Ok(dashboard);
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

        private int GetCurrentManagerId()
        {
            // Assuming you have user claims and the manager ID is stored as a claim
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "ManagerId")?.Value;
            if (int.TryParse(userIdClaim, out var managerId))
            {
                return managerId;
            }
            throw new UnauthorizedAccessException("Manager ID could not be determined.");
        }
    }
}
