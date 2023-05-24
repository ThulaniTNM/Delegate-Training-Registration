using System.ComponentModel.DataAnnotations.Schema;

namespace Delegate_Training_Registration.DataAccess.Models
{
    public class Training
    {
        public Guid TrainingID { get; set; }
        public string TrainingName { get; set; }
        public string TrainingVenue { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TrainingCost { get; set; }
        public DateTime TrainingDate { get; set; }
        public DateTime TrainingRegistrationClosingDate { get; set; }
        public int AvailableSeats { get; set; }
        // navigation props
        [ForeignKey(nameof(Course))]
        public Guid CourseCode { get; set; }
        public Course Course { get; set; }
    }
}
