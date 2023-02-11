using GPACalculator.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GPACalculator.Features.Courses.AddStudentToCourse
{

    public interface IAddStudentToCourseRepository
    {
        Task AddStudentToCourseAsync(AddStudentToCourseRequest request);
        Task SaveChangesAsync();
    }

    public class AddStudentToCourseRepository : IAddStudentToCourseRepository
    {
        private readonly GPACalculatorDbContext _context;

        public AddStudentToCourseRepository(GPACalculatorDbContext context)
        {
            _context = context;
        }


        public async Task AddStudentToCourseAsync(AddStudentToCourseRequest request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == request.StudentId);

            if(student == null)
            {
                throw new ArgumentException("Can't identify user");
            }

            var choosenCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == request.CourseId);

            if(choosenCourse == null)
            {
                throw new ArgumentException("Course doesn't exist");
            }

            choosenCourse.EnrolledStudents.Add(student);
            student.Courses.Add(choosenCourse);


        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
