using GPACalculator.Db;
using GPACalculator.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPACalculator.Features.Students.CalculateGPA
{

    public interface ICalculateGPAService
    {
        Task<double> CalculateStudentGpaAsync(Guid studentId);
        Task SaveChangesAsync();
    }

    public class CalculateGPAService : ICalculateGPAService
    {
        private readonly GPACalculatorDbContext _context;

        public CalculateGPAService(GPACalculatorDbContext context)
        {
            _context = context;
        }

        private double ConvertGradeToGP(int grade)
        {
            if (grade >= 91)
            {
                return 4.0;
            }
            if (grade >= 81)
            {
                return 3;
            }
            if (grade >= 71)
            {
                return 2;
            }
            if (grade >= 61)
            {
                return 1;
            }
            if (grade >= 51)
            {
                return 0.5;
            }

            return 0;

        }

        private double GPACalculator(
            List<GradeEntity> grades,
            List<CourseEntity> courses)
        {

            int creditsSum = courses.Sum(c => c.Credit);
            double gpaSum = 0;

            foreach (var grade in grades)
            {
                var course = courses.First(c => c.Id == grade.CourseId);

                gpaSum += ConvertGradeToGP(grade.Grade) * course!.Credit;

            }

            var gpa = gpaSum / creditsSum;

            return gpa;
        }

        public async Task<double> CalculateStudentGpaAsync(Guid studentId)
        {
            var studentGrades = await _context.Grades
                .Where(g => g.StudentId == studentId)
                .ToListAsync();

            var courses = await _context.Courses.ToListAsync();

            var studentTakenCourses = courses
                .Where(c => studentGrades.Any(g => g.CourseId == c.Id))
                .ToList();

            var gpa = GPACalculator(studentGrades, courses);


            return 0;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
