using System.ComponentModel.DataAnnotations;

namespace GPACalculator.Db.Entities
{
    public class GradeEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public int Grade { get; set; }


    }
}
