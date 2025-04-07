using Microsoft.AspNetCore.Mvc;
using MySchoolAPI.Models;
using System.Diagnostics;

namespace MySchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherApiController : ControllerBase
    {
        private readonly SchoolDbAccess _db;

        public TeacherApiController()
        {
            _db = new SchoolDbAccess();
        }

        /// <summary>
        /// Get all teachers from the database.
        /// </summary>
        /// <returns>A list of teachers</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _db.GetAllTeachers();

            if (teachers == null || teachers.Count == 0)
            {
                Debug.WriteLine("API: No teachers found.");
                return NotFound("No teachers found");
            }

            return Ok(teachers);
        }

        /// <summary>
        /// Get a teacher by ID.
        /// </summary>
        /// <param name="id">Teacher ID</param>
        /// <returns>Teacher object</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _db.GetTeacherById(id);

            if (teacher == null)
            {
                Debug.WriteLine($"API: Teacher with ID {id} not found.");
                return NotFound($"No teacher found with ID {id}");
            }

            return Ok(teacher);
        }

        /// <summary>
        /// Add a new teacher.
        /// </summary>
        /// <param name="teacher">Teacher object</param>
        /// <returns>Result message</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Teacher teacher)
        {
            if (teacher == null)
            {
                Debug.WriteLine("API: Received null teacher object.");
                return BadRequest("Teacher info cannot be empty.");
            }

            _db.AddTeacher(teacher);

            Debug.WriteLine($"API: New teacher added.");

            return Ok("Teacher added successfully");
        }

        /// <summary>
        /// Delete a teacher by ID.
        /// </summary>
        /// <param name="id">Teacher ID</param>
        /// <returns>Status</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _db.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound($"No teacher found with ID {id}");
            }

            _db.DeleteTeacher(id);
            return Ok($"Teacher with ID {id} has been deleted.");
        }
    }
}
