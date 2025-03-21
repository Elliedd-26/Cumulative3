using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolAPI.Models;
using System.Diagnostics;

namespace MySchoolAPI.Controllers
{
    [Route("Teacher")]
    public class TeacherController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: /Teacher/ or /Teacher/List
        [HttpGet("")]
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var teacherList = await _context.Teachers.ToListAsync();

            if (teacherList == null || teacherList.Count == 0)
            {
                Debug.WriteLine("No teachers found in the database.");
                ViewBag.Message = "No teachers found.";
                return View(new List<Teacher>()); // Pass empty list to avoid null view model
            }

            return View(teacherList); // /Views/Teacher/List.cshtml
        }

        // GET: /Teacher/Show/{id}
        [HttpGet("Show/{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                Debug.WriteLine($"Teacher with ID {id} not found.");
                return NotFound($"No teacher found with ID {id}");
            }

            return View(teacher); // /Views/Teacher/Show.cshtml
        }
    }
}
