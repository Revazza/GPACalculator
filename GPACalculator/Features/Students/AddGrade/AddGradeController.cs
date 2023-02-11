using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.Features.Students.AddGrade
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddGradeController : ControllerBase
    {
        private readonly IAddGradeRepository _repository;

        public AddGradeController(IAddGradeRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("add-student/{studentId}/grade")]
        public async Task<IActionResult> AddGradeToStudent(Guid studentId, AddGradeRequest request)
        {

            await _repository.AddGradeToStudentAsync(studentId,request);

            await _repository.SaveChangesAsync();

            return Ok("Grade added");
        }


    }
}
