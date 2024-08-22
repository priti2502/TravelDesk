using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Data;
using TravelDesk.DTO;
using TravelDesk.Models;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRequestController : ControllerBase
    {
        private readonly TravelDeskContext _context;

        public TravelRequestController(TravelDeskContext context)
        {
            _context = context;
        }

        // GET: api/TravelRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelRequestDto>>> GetTravelRequests()
        {
            var travelRequests = await _context.TravelRequests
                .Include(tr => tr.User)
                .Include(tr => tr.Project)
                
                .Include(tr => tr.User.Department)
                .Select(tr => new TravelRequestDto
                {
                    TravelRequestId = tr.TravelRequestId,
                    
                    User = new UserDto
                    {
                        UserId = tr.User.UserId,
                        FirstName = tr.User.FirstName,
                        LastName=tr.User.LastName,

                        Department = new DepartmentDto
                        {
                            DepartmentId = tr.User.Department.DepartmentId,
                            DepartmentName = tr.User.Department.DepartmentName
                        }
                    },
                    Project = new ProjectDto
                    {
                        ProjectId = tr.Project.ProjectId,
                        ProjectName = tr.Project.ProjectName
                    }
                })
                .ToListAsync();

            return Ok(travelRequests);
        }


        // GET: api/TravelRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelRequest>> GetTravelRequest(int id)
        {
            var travelRequest = await _context.TravelRequests.FindAsync(id);

            if (travelRequest == null)
            {
                return NotFound();
            }

            return travelRequest;
        }

        [HttpPost]
        public async Task<IActionResult> PostTravelRequest(TravelRequest travelRequest)
        {
             

            _context.TravelRequests.Add(travelRequest);

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details
              
                return StatusCode(500, "Internal server error.");
            }
        }


        // PUT: api/TravelRequest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelRequest(int id, TravelRequest travelRequest)
        {
            if (id != travelRequest.TravelRequestId)
            {
                return BadRequest();
            }

            _context.Entry(travelRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelRequestExists(id))
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

        // DELETE: api/TravelRequest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelRequest(int id)
        {
            var travelRequest = await _context.TravelRequests.FindAsync(id);
            if (travelRequest == null)
            {
                return NotFound();
            }

            _context.TravelRequests.Remove(travelRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelRequestExists(int id)
        {
            return _context.TravelRequests.Any(e => e.TravelRequestId == id);
        }
    }
}
