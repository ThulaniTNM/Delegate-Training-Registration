using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        private readonly DelegateTrainingRegistrationContext _context;

        public TrainingRepository(DelegateTrainingRegistrationContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Training> GetTrainings(Guid courseCode, bool isTrackingChanges)
        {
            var courseTrainings = this.GetByCondition(training => training.CourseCode.Equals(courseCode), isTrackingChanges);
            return courseTrainings.OrderBy(training => training.TrainingName);
        }

        public Training GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges)
        {
            var courseTrainings = this.GetByCondition(training =>
                                                                                training.CourseCode.Equals(courseCode) && training.TrainingID.Equals(trainingId),
                                                                                isTrackingChanges);

            var training = courseTrainings.FirstOrDefault();
            return training;
        }
    }
}
