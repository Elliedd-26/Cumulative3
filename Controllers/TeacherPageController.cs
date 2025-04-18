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

 // GET: /Teacher/Edit/{id}
[HttpGet("Edit/{id}")]
public IActionResult Edit(int id)
{
    var teacher = _db.GetTeacherById(id);
    if (teacher == null)
    {
        return NotFound($"No teacher found with ID {id}");
    }


    ViewData.ModelState.Clear();

    return View(teacher);
}

// POST: /Teacher/Edit/{id}
[HttpPost("Edit/{id}")]
public IActionResult Edit(int id, Teacher teacher)
{
    if (string.IsNullOrWhiteSpace(teacher.TeacherFname) || string.IsNullOrWhiteSpace(teacher.TeacherLname))
    {
        ModelState.AddModelError("", "Name fields cannot be empty.");
        return View(teacher);
    }

    if (teacher.HireDate > DateTime.Now)
    {
        ModelState.AddModelError("", "Hire date cannot be in the future.");
        return View(teacher);
    }

    if (teacher.Salary < 0)
    {
        ModelState.AddModelError("", "Salary cannot be negative.");
        return View(teacher);
    }

    _db.UpdateTeacher(id, teacher);
    return RedirectToAction("Show", new { id = id });
}



    }
}
