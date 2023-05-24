using System.ComponentModel.DataAnnotations.Schema;

namespace Delegate_Training_Registration.DataAccess.Models
{
    public class Training
    {
        public int TrainingID { get; set; }
        public string TrainingName { get; set; }
        public string TrainingVenue { get; set; }
        public string TrainingCost { get; set; }
        public DateTime TrainingDate { get; set; }
        public DateTime TrainingRegistrationClosingDate { get; set; }
        public int AvailableSeats { get; set; }
        // navigation props
        [ForeignKey(nameof(Course))]
        public Guid CourseCode { get; set; }
        public Course Course { get; set; }
    }
}
