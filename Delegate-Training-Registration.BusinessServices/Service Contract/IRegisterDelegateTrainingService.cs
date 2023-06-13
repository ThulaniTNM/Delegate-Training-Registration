namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface IRegisterDelegateTrainingService
    {
        public void CreateDelegateTraining(Guid personID, Guid trainingID);
    }
}
