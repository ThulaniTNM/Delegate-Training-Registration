using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface ITrainingService
    {
        IEnumerable<TrainingReadDTO> GetTrainings(Guid courseCode, bool isTrackingChanges);
        TrainingReadDTO GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges);
        TrainingReadDTO CreateTraining(Guid courseCode, TrainingWriteDTO trainingCreateDTO);
        void DeleteTraining(Guid courseCode, Guid trainingId);
        void UpdateTraining(Guid courseCode, Guid trainingId, TrainingWriteDTO trainingUpdate);
    }
}
