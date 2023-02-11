using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.Features.Courses.AddCourse
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCourseController : ControllerBase
    {
        private readonly IAddCourseRepository _repository;

        public AddCourseController(IAddCourseRepository repository)
        {
            _repository = repository;
        }



        [HttpPost("add-course")]
        public async Task<IActionResult> AddCourse(AddCourseRequest request)
        {

            var courseId = await _repository.AddCourseAsync(request);
            await _repository.SaveChangesAsync();

            return Ok(courseId);

        }



    }
}
