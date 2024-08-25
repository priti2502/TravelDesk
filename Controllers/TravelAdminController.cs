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

        // Endpoint to retrieve all travel requests
        [HttpGet("GetAllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var travelRequests = await _context.TravelRequests
                    
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
        public async Task<IActionResult> BookTicket(int travelRequestId, [FromBody] BookingDetails bookingDetails)
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
                travelRequest.Comments = bookingDetails.Comments; // Update comments

                // Save the booking confirmation URL if available
                if (!string.IsNullOrEmpty(bookingDetails.TicketUrl))
                {
                    travelRequest.TicketUrl = bookingDetails.TicketUrl;
                }

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
        public async Task<IActionResult> ReturnToManager(int travelRequestId, [FromBody] BookingDetails bookingDetails)
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
                travelRequest.Comments = bookingDetails.Comments;
             

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
        public async Task<IActionResult> ReturnToEmployee(int travelRequestId, [FromBody] BookingDetails bookingDetails)
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
                travelRequest.Comments = bookingDetails.Comments;
               

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
        public async Task<IActionResult> CloseRequest(int travelRequestId, [FromBody] BookingDetails bookingDetails)
        {
            // Ensure that CommentsRequest class matches the expected JSON payload
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
                //travelRequest.Comments = bookingDetails.Comments;
               

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
