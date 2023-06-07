using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface ITrainingService
    {
        IEnumerable<Training> GetTrainings(Guid courseCode, bool isTrackingChanges);
        Training GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges);
        void CreateTraining(Guid courseCode, Training training);
        void DeleteTraining(Guid courseCode, Guid trainingId);
        void UpdateTraining(Guid courseCode, Guid trainingId, Training training);
    }
}
