using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public ManagerController(TravelDeskContext context)
        {
            _context = context;
        }

        // GET: api/Manager/{managerId}/Requests
        [HttpGet("{managerId}/Requests")]
        public async Task<ActionResult<IEnumerable<TravelRequestDto>>> GetPendingRequests(int managerId)
        {
            var pendingRequests = await _context.TravelRequests
                .Where(tr => tr.User.ManagerId == managerId && tr.Status == "Pending")
                .Include(tr => tr.Project)
                .Include(tr => tr.User)
                .Select(tr => new TravelRequestDto
                {
                    TravelRequestId = tr.TravelRequestId,
                    Project = new ProjectDto
                    {
                        ProjectId = tr.Project.ProjectId,
                        ProjectName = tr.Project.ProjectName
                    },
                    User = new UserDto
                    {
                        UserId = tr.User.UserId,
                        FirstName = tr.User.FirstName,
                        LastName = tr.User.LastName
                       
                    },
                    ReasonForTravel = tr.ReasonForTravel,
                    FromDate = tr.FromDate,
                    ToDate = tr.ToDate,
                    FromLocation = tr.FromLocation,
                    ToLocation = tr.ToLocation,
                    Status = tr.Status,
                    Comments = tr.Comments
                })
                .ToListAsync();

            if (!pendingRequests.Any())
            {
                return NotFound("No pending requests found for this manager.");
            }

            return Ok(pendingRequests);
        }
        [HttpPut("ApproveRequest/{requestId}")]
        public async Task<IActionResult> ApproveRequest(int requestId, [FromBody] CommentDto commentDto)
        {
            var travelRequest = await _context.TravelRequests.FindAsync(requestId);
            if (travelRequest == null)
            {
                return NotFound();
            }

            travelRequest.Status = "Approved";
            travelRequest.Comments = commentDto.Comments; // Access comments from the DTO
            _context.Entry(travelRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelRequestExists(requestId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("RejectRequest/{requestId}")]
        public async Task<IActionResult> RejectRequest(int requestId, [FromBody] CommentDto commentDto)
        {
            var travelRequest = await _context.TravelRequests.FindAsync(requestId);
            if (travelRequest == null)
            {
                return NotFound();
            }

            travelRequest.Status = "Rejected";
            travelRequest.Comments = commentDto.Comments; // Access comments from the DTO
            _context.Entry(travelRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelRequestExists(requestId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TravelRequestExists(int id)
        {
            return _context.TravelRequests.Any(e => e.TravelRequestId == id);
        }
    }
}
