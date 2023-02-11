using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPACalculator.Features.Students.CalculateGPA
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateGPAController : ControllerBase
    {
        private readonly ICalculateGPAService _service;

        public CalculateGPAController(ICalculateGPAService service)
        {
            _service = service;
        }


        [HttpPost("student/{studentId}/gpa")]
        public async Task<IActionResult> CalculateStudentGPA(Guid studentId)
        {

            var gpa = await _service.CalculateStudentGpaAsync(studentId);


            return Ok(gpa);
        }


    }
}
