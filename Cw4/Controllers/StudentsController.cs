using System.Linq;
using Cw4.Services;
using Cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private static IDbStudentService _dbService;

        public StudentsController(IDbStudentService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_dbService.GetEntries());
        }

        [HttpGet("{idStudent}")]
        public IActionResult GetStudent([FromRoute] string idStudent)
        {
            var student = _dbService.GetEnrolled(idStudent);
            if (student == null) return NotFound($"Student not found ID : {idStudent}!");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent([FromBody] Student student)
        {
            var affectedRows = _dbService.AddEntry(student);
            return Ok($"Modified {affectedRows} rows in database.");
        }

        [HttpPut("{idStudent}")]
        public IActionResult PutStudent([FromRoute] string idStudent, [FromBody] Student newStudent)
        {
            newStudent.IndexNumber = idStudent;
            var affectedRows = _dbService.UpdateEntry(newStudent);
            return affectedRows == 0
                ? (IActionResult)NotFound($"Student not found ID : {idStudent}!")
                : Ok($"Modified {affectedRows} rows in database.");
        }

        [HttpDelete("{idStudent}")]
        public IActionResult DeleteStudent([FromRoute] string idStudent)
        {
            var affectedRows = _dbService.RemoveEntry(idStudent);
            return affectedRows == 0
                ? (IActionResult)NotFound($"Student not found ID : {idStudent}!")
                : Ok($"Modified {affectedRows} rows in database.");
        }
    }
}