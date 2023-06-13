using AutoMapper;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class RegisterDelegateTrainingService : IRegisterDelegateTrainingService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RegisterDelegateTrainingService(IRepositoryManager repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public void CreateDelegateTraining(Guid personID, Guid trainingID)
        {
            var registeredDelegateTraining = new RegisterDelegateTrainings() { PersonID = personID, TrainingID = trainingID };
            this._repository.RegisterDelegateTrainings.Create(registeredDelegateTraining);
        }
    }
}
