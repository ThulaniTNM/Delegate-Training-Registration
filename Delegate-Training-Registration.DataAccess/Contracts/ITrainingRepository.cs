using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.DataAccess.Contracts
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> GetTrainings(Guid courseCode, bool isTrackingChanges);
        Training GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges); // sub-collection-> single resource.
    }
}
