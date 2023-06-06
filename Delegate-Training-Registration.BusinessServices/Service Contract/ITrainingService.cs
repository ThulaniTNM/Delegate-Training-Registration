using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface ITrainingService
    {
        IEnumerable<Training> GetTrainings(Guid courseCode, bool isTrackingChanges);
        Training GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges); // get sub-collection individual resource.
        void CreateTraining(Guid courseCode, Training training);
        void DeleteTraining(Guid courseCode, Guid trainingId);
    }
}
