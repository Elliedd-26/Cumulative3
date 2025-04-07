using Microsoft.AspNetCore.Mvc;
using MySchoolAPI.Models;
using System.Diagnostics;

namespace MySchoolAPI.Controllers
{
    [Route("Teacher")]
    public class TeacherController : Controller
    {
        private readonly SchoolDbAccess _db;

        public TeacherController()
        {
            _db = new SchoolDbAccess();
        }

        // GET: /Teacher/ or /Teacher/List
        [HttpGet("")]
        [HttpGet("List")]
        public IActionResult List()
        {
            var teacherList = _db.GetAllTeachers();

            if (teacherList == null || teacherList.Count == 0)
            {
                Debug.WriteLine("No teachers found in the database.");
                ViewBag.Message = "No teachers found.";
                return View(new List<Teacher>()); // 传入空列表以避免视图为 null
            }

            return View(teacherList); // → /Views/Teacher/List.cshtml
        }

        // GET: /Teacher/Show/{id}
        [HttpGet("Show/{id}")]
        public IActionResult Show(int id)
        {
            var teacher = _db.GetTeacherById(id);

            if (teacher == null)
            {
                Debug.WriteLine($"Teacher with ID {id} not found.");
                return NotFound($"No teacher found with ID {id}");
            }

            return View(teacher); // → /Views/Teacher/Show.cshtml
        }
    }
}
