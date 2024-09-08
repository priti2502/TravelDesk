using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Data;
using TravelDesk.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace TravelDesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelAdminController : ControllerBase
    {
        private readonly TravelDeskContext _context;

        public TravelAdminController(TravelDeskContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var travelRequests = await _context.TravelRequests
                    .Include(tr => tr.User)
                    .Include(tr => tr.Project)  // Ensure Project is included
                    .Include(tr => tr.Department)  // Ensure Department is included
                    .Select(tr => new
                    {
                        tr.TravelRequestId,
                        tr.Status,
                        tr.FromDate,
                        tr.ToDate,
                        tr.ReasonForTravel,
                        tr.FromLocation,
                        tr.ToLocation,
                        User = new
                        {
                            tr.User.UserId,
                            tr.User.FirstName,
                            tr.User.LastName,
                            tr.User.Email
                        },
                        Project = new
                        {
                            tr.Project.ProjectId,
                            tr.Project.ProjectName
                        },
                        Department = new
                        {
                            tr.Department.DepartmentId,
                            tr.Department.DepartmentName
                        }
                    })
                    .ToListAsync();

                if (travelRequests == null || travelRequests.Count == 0)
                {
                    return NotFound("No travel requests found.");
                }

                return Ok(travelRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("BookTicket/{travelRequestId}")]
        public async Task<IActionResult> BookTicket(int travelRequestId)
        {
            try
            {
                var travelRequest = await _context.TravelRequests
                    .Include(tr => tr.User) // Include user details
                    .FirstOrDefaultAsync(tr => tr.TravelRequestId == travelRequestId);

                if (travelRequest == null)
                {
                    return NotFound("Travel request not found.");
                }

                // Update the travel request with booking details
                travelRequest.Status = "Booked";
                // No comments update here

                _context.TravelRequests.Update(travelRequest);
                await _context.SaveChangesAsync();

                // Notify the employee via the history update
                return Ok("Booking confirmed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("ReturnToManager/{travelRequestId}")]
        public async Task<IActionResult> ReturnToManager(int travelRequestId)
        {
            try
            {
                var travelRequest = await _context.TravelRequests
                    .FirstOrDefaultAsync(tr => tr.TravelRequestId == travelRequestId);

                if (travelRequest == null)
                {
                    return NotFound("Travel request not found.");
                }

                // Reassign request to manager
                travelRequest.Status = "Returned to Manager";
                // No comments update here

                _context.TravelRequests.Update(travelRequest);
                await _context.SaveChangesAsync();

                return Ok("Request returned to manager successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("ReturnToEmployee/{travelRequestId}")]
        public async Task<IActionResult> ReturnToEmployee(int travelRequestId)
        {
            try
            {
                var travelRequest = await _context.TravelRequests
                    .FirstOrDefaultAsync(tr => tr.TravelRequestId == travelRequestId);

                if (travelRequest == null)
                {
                    return NotFound("Travel request not found.");
                }

                // Reassign request to employee
                travelRequest.Status = "Returned to Employee";
                // No comments update here

                _context.TravelRequests.Update(travelRequest);
                await _context.SaveChangesAsync();

                return Ok("Request returned to employee successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CloseRequest/{travelRequestId}")]
        public async Task<IActionResult> CloseRequest(int travelRequestId)
        {
            try
            {
                var travelRequest = await _context.TravelRequests
                    .FirstOrDefaultAsync(tr => tr.TravelRequestId == travelRequestId);

                if (travelRequest == null)
                {
                    return NotFound("Travel request not found.");
                }

                // Close the request with complete status
                travelRequest.Status = "Completed";
                // No comments update here

                _context.TravelRequests.Update(travelRequest);
                await _context.SaveChangesAsync();

                return Ok("Request closed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
