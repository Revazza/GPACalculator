using GPACalculator.Db;
using GPACalculator.Db.Entities;

namespace GPACalculator.Features.Courses.AddCourse
{

    public interface IAddCourseRepository
    {
        Task<Guid> AddCourseAsync(AddCourseRequest newCourse);
        Task SaveChangesAsync();

    }

    public class AddCourseRepository : IAddCourseRepository
    {
        private readonly GPACalculatorDbContext _context;

        public AddCourseRepository(GPACalculatorDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> AddCourseAsync(AddCourseRequest newCourse)
        {
            var isCourseUnique = !_context.Courses.Any(s => s.Name == newCourse.Name);

            if (!isCourseUnique)
            {
                throw new ArgumentException($"Course with name {newCourse.Name} already exists");
            }

            var courseToAdd = new CourseEntity()
            {
                Name = newCourse.Name,
                Credit = newCourse.CourseCredit
            };

            await _context.Courses.AddAsync(courseToAdd);

            return courseToAdd.Id;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
