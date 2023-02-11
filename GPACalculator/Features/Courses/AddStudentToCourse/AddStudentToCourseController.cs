using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.Features.Courses.AddStudentToCourse
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddStudentToCourseController : ControllerBase
    {
        private readonly IAddStudentToCourseRepository _repository;

        public AddStudentToCourseController(IAddStudentToCourseRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("add-student-to-course")]
        public async Task<IActionResult> AddStudentToCourse(AddStudentToCourseRequest request)
        {

            await _repository.AddStudentToCourseAsync(request);

            await _repository.SaveChangesAsync();

            return Ok();
        }


    }
}
