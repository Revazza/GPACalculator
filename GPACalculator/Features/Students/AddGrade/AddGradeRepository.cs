using GPACalculator.Db;
using GPACalculator.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPACalculator.Features.Students.AddGrade
{

    public interface IAddGradeRepository
    {
        Task AddGradeToStudentAsync(Guid studentId, AddGradeRequest request);
        Task SaveChangesAsync();
    }

    public class AddGradeRepository : IAddGradeRepository
    {
        private readonly GPACalculatorDbContext _context;

        public AddGradeRepository(GPACalculatorDbContext context)
        {
            _context = context;
        }

        public async Task AddGradeToStudentAsync(Guid studentId, AddGradeRequest request)
        {

            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                throw new ArgumentException("Can't find student");
            }

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == request.CourseId);

            if (course == null)
            {
                throw new ArgumentException("Can't find course");
            }

            var grade = await _context.Grades
                .FirstOrDefaultAsync(s => s.StudentId == studentId && s.CourseId == request.CourseId);

            if (grade != null)
            {
                throw new ArgumentException("Student already been graded");
            }

            var newGrade = new GradeEntity()
            {
                StudentId = studentId,
                CourseId = request.CourseId,
                Grade = request.Grade
            };

            await _context.Grades.AddAsync(newGrade);

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
