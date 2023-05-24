using System.ComponentModel.DataAnnotations;

namespace Delegate_Training_Registration.DataAccess.Models
{
    public class Course
    {
        [Key]
        public Guid CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

        // navigation props
        public ICollection<Training> Trainings { get; set; }
    }
}
