using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolAPI.Models;
using System.Diagnostics;

[Route("api/[controller]")]
    [ApiController]
    public class TeacherApiController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TeacherApiController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: /api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            var teachers = await _context.Teachers.ToListAsync();

            if (teachers == null || teachers.Count == 0)
            {
                Debug.WriteLine("API: No teachers found.");
                return NotFound("No teachers found");
            }

            return Ok(teachers);
        }

        // GET: /api/Teacher/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                Debug.WriteLine($"API: Teacher with ID {id} not found.");
                return NotFound($"No teacher found with ID {id}");
            }

            return Ok(teacher);
        }

        // POST: /api/Teacher
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Teacher teacher)
        {
            if (teacher == null)
            {
                Debug.WriteLine("API: Received null teacher object.");
                return BadRequest("Teacher info cannot be empty.");
            }


            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            Debug.WriteLine($"API: New teacher added with ID {teacher.TeacherId}");

            return CreatedAtAction(nameof(GetById), new { id = teacher.TeacherId }, teacher);
        }
    }
