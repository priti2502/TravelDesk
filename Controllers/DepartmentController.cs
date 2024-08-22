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
    public class DepartmentController : ControllerBase
    {
        private readonly TravelDeskContext _context;

        public DepartmentController(TravelDeskContext context)
        {
            _context = context;
        }

        // GET: api/department
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return Ok(departments);
        }

       
       
    }
}
