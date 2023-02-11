using System.ComponentModel.DataAnnotations;

namespace GPACalculator.Db.Entities
{
    public class CourseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public byte Credit { get; set; }

        public List<StudentEntity> EnrolledStudents { get; set; }


        public CourseEntity()
        {
            EnrolledStudents = new List<StudentEntity>();
        }


    }
}
