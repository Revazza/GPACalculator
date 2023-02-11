using System.ComponentModel.DataAnnotations;

namespace GPACalculator.Db.Entities
{
    public class StudentEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalNumber { get; set; }
        public List<CourseEntity> Courses { get; set; }


        public StudentEntity()
        {
            Courses = new List<CourseEntity>();
        }


    }
}
