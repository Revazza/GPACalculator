using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.Features.Students.AddStudent
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddStudentController : ControllerBase
    {
        private readonly IAddStudentRepository _repository;

        public AddStudentController(IAddStudentRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent(AddStudentRequest request)
        {

            await _repository.AddStudentAsync(request);
            await _repository.SaveChangesAsync();
            return Ok();
        }


    }
}
