using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Data;
using TravelDesk.DTO;
using TravelDesk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using iTextSharp.text.pdf;
using iTextSharp.text;

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
        public async Task<ActionResult<DashboardDto>> GetTravelRequests()
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
                        LastName = tr.User.LastName,
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

            var dashboard = new DashboardDto
            {
                Requests = travelRequests
            };

            return Ok(dashboard);
        }
        [HttpPost]
        public async Task<IActionResult> PostTravelRequest(TravelRequest travelRequest)
        {
            // Ensure status and comments are not included
            travelRequest.Status = "Pending"; // Default status
            travelRequest.Comments = null; // Default comments

            _context.TravelRequests.Add(travelRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTravelRequests), new { id = travelRequest.TravelRequestId }, travelRequest);
        }
       
        [HttpPut("{TravelRequestId}")]
                public async Task<IActionResult> UpdateTravelRequest(int TravelRequestId, TravelRequest travelRequestUpdate)
                {
                    // Find the existing travel request
                    var travelRequest = await _context.TravelRequests.FindAsync(TravelRequestId);
 
                    if (travelRequest == null)
                    {
                        return NotFound($"Travel request with ID {TravelRequestId} not found.");
                    }
 
                    travelRequest.ReasonForTravel = travelRequestUpdate.ReasonForTravel;
                    travelRequest.FromDate = travelRequestUpdate.FromDate;
                    travelRequest.ToDate = travelRequestUpdate.ToDate;
                    travelRequest.FromLocation = travelRequestUpdate.FromLocation;
                    travelRequest.ToLocation = travelRequestUpdate.ToLocation;
                    travelRequest.Status = "Updated";
                    //travelRequest.Comments = travelRequestUpdate.Comments;
                    //travelRequest.TicketUrl = travelRequestUpdate.TicketUrl;
                    travelRequest.ModifiedOn = DateTime.Now; // Set the modification time
 
   
                    _context.Entry(travelRequest).State = EntityState.Modified;
 
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TravelRequestExists(TravelRequestId))
                        {
                            return NotFound($"Travel request with ID {TravelRequestId} not found.");
                        }
                        else
                        {
                            throw;
                        }
                    }
 
                    return NoContent();
}


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<TravelRequestDto>>> GetTravelRequestsByUserId(int userId)
        {
            var travelRequests = await _context.TravelRequests
                .Where(tr => tr.UserId == userId)
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
                        LastName = tr.User.LastName,
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

            if (travelRequests == null || !travelRequests.Any())
            {
                return NotFound("No travel requests found for this user.");
            }

            return Ok(travelRequests);
        }


        [HttpGet("DownloadTicket/{travelRequestId}")]
        public IActionResult DownloadTicket(int travelRequestId)
        {
            try
            {
                var travelRequest = _context.TravelRequests
                    .Include(tr => tr.User)
                    .Include(tr => tr.Project)  // Ensure Project is included
                    .FirstOrDefault(tr => tr.TravelRequestId == travelRequestId);

                if (travelRequest == null)
                {
                    return NotFound("Travel request not found.");
                }

                using (var stream = new MemoryStream())
                {
                    var pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Metadata
                    pdfDoc.AddAuthor("Travel Desk");
                    pdfDoc.AddCreator("Travel Desk Application");
                    pdfDoc.AddTitle("Travel Request Ticket");

                    // Define Fonts and Colors
                    var titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    var headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    var sectionFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    var bodyFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);
                    var tableFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);
                    var footerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);

                    // Header Section
                    pdfDoc.Add(new Paragraph("Travel Request Ticket", titleFont));
                    pdfDoc.Add(new Paragraph("\n"));

                    // Ticket Information Section
                    var ticketInfoTable = new PdfPTable(2);
                    ticketInfoTable.WidthPercentage = 100;
                    ticketInfoTable.SetWidths(new float[] { 1f, 2f });
                    ticketInfoTable.AddCell(GetStyledCell("Ticket ID:", sectionFont, true));
                    ticketInfoTable.AddCell(GetStyledCell(travelRequest.TravelRequestId.ToString(), bodyFont));
                    ticketInfoTable.AddCell(GetStyledCell("Booking Date:", sectionFont, true));
                    ticketInfoTable.AddCell(GetStyledCell(DateTime.Now.ToShortDateString(), bodyFont));
                    pdfDoc.Add(ticketInfoTable);
                    pdfDoc.Add(new Paragraph("\n"));

                    // Passenger Information
                    pdfDoc.Add(new Paragraph("Passenger Information", sectionFont));
                    pdfDoc.Add(new Paragraph("\n"));
                    var passengerInfoTable = new PdfPTable(2);
                    passengerInfoTable.WidthPercentage = 100;
                    passengerInfoTable.SetWidths(new float[] { 1f, 2f });
                    passengerInfoTable.AddCell(GetStyledCell("Name:", tableFont, true));
                    passengerInfoTable.AddCell(GetStyledCell($"{travelRequest.User.FirstName} {travelRequest.User.LastName}", bodyFont));
                    passengerInfoTable.AddCell(GetStyledCell("Email:", tableFont, true));
                    passengerInfoTable.AddCell(GetStyledCell(travelRequest.User.Email, bodyFont));
                    passengerInfoTable.AddCell(GetStyledCell("Phone Number:", tableFont, true));
                    passengerInfoTable.AddCell(GetStyledCell(travelRequest.User.MobileNum, bodyFont));
                    pdfDoc.Add(passengerInfoTable);
                    pdfDoc.Add(new Paragraph("\n"));

                    // Travel Details Table
                    pdfDoc.Add(new Paragraph("Travel Information", sectionFont));
                    pdfDoc.Add(new Paragraph("\n"));
                    var travelInfoTable = new PdfPTable(2);
                    travelInfoTable.WidthPercentage = 100;
                    travelInfoTable.SetWidths(new float[] { 1f, 2f });
                    travelInfoTable.AddCell(GetStyledCell("From Date:", tableFont, true));
                    travelInfoTable.AddCell(GetStyledCell(travelRequest.FromDate.ToShortDateString(), bodyFont));
                    travelInfoTable.AddCell(GetStyledCell("To Date:", tableFont, true));
                    travelInfoTable.AddCell(GetStyledCell(travelRequest.ToDate.ToShortDateString(), bodyFont));
                    travelInfoTable.AddCell(GetStyledCell("From Location:", tableFont, true));
                    travelInfoTable.AddCell(GetStyledCell(travelRequest.FromLocation, bodyFont));
                    travelInfoTable.AddCell(GetStyledCell("To Location:", tableFont, true));
                    travelInfoTable.AddCell(GetStyledCell(travelRequest.ToLocation, bodyFont));
                    pdfDoc.Add(travelInfoTable);
                    pdfDoc.Add(new Paragraph("\n"));

                    // Booking Information
                    pdfDoc.Add(new Paragraph("Booking Details", sectionFont));
                    pdfDoc.Add(new Paragraph("\n"));
                    var bookingInfoTable = new PdfPTable(2);
                    bookingInfoTable.WidthPercentage = 100;
                    bookingInfoTable.SetWidths(new float[] { 1f, 2f });
                    bookingInfoTable.AddCell(GetStyledCell("Reason for Travel:", tableFont, true));
                    bookingInfoTable.AddCell(GetStyledCell(travelRequest.ReasonForTravel, bodyFont));
                    bookingInfoTable.AddCell(GetStyledCell("Project Name:", tableFont, true));
                    bookingInfoTable.AddCell(GetStyledCell(travelRequest.Project?.ProjectName ?? "N/A", bodyFont)); // Handle potential null
                    bookingInfoTable.AddCell(GetStyledCell("Comments:", tableFont, true));
                    bookingInfoTable.AddCell(GetStyledCell(travelRequest.Comments ?? "N/A", bodyFont)); // Handle potential null
                    pdfDoc.Add(bookingInfoTable);
                    pdfDoc.Add(new Paragraph("\n"));

                    // Footer Section
                    pdfDoc.Add(new Paragraph("For Support, Contact: +1 234 567 890 | Email: support@traveldesk.com", footerFont));
                    pdfDoc.Add(new Paragraph("Thank you for using TravelDesk. We wish you a pleasant journey.", footerFont));
                    pdfDoc.Add(new Paragraph("QR Code Placeholder", footerFont));

                    pdfDoc.Close();

                    var pdfBytes = stream.ToArray();
                    return File(pdfBytes, "application/pdf", "TravelRequestTicket.pdf");
                }
            }
            catch (Exception ex)
            {
                // Log the error (not shown here for brevity)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Helper function to create styled cells
        private PdfPCell GetStyledCell(string text, Font font, bool isHeader = false)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font))
            {
                BackgroundColor = isHeader ? BaseColor.LIGHT_GRAY : BaseColor.WHITE,
                BorderWidth = 1f,
                Padding = 8f
            };

            return cell;
        }













        private bool TravelRequestExists(int id)
        {
            return _context.TravelRequests.Any(e => e.TravelRequestId == id);
        }
    }
}
