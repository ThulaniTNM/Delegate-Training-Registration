using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delegate_Training_Registration.DataAccess.Models
{
    public class RegisterDelegateTrainings
    {
        [Key]
        public Guid RegisteredTrainingsID { get; set; }

        // navigation props
        [ForeignKey(nameof(Person))]
        public Guid PersonID { get; set; }
        public Person Person { get; set; }

        [ForeignKey(nameof(Training))]
        public Guid TrainingID { get; set; }
        public Training Training { get; set; }
    }
}
