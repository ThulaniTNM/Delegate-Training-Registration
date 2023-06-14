using AutoMapper;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IPhysicalAddressService _physicalAddressService;
        private readonly IRegisterDelegateTrainingService _registerDelegateTrainingService;

        public PersonService(IRepositoryManager repository, IMapper mapper, IPhysicalAddressService physicalAddressService, IRegisterDelegateTrainingService registerDelegateTrainingService)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._physicalAddressService = physicalAddressService;
            this._registerDelegateTrainingService = registerDelegateTrainingService;
        }
        public PersonReadDTO RegisterPerson(PersonWriteDTO personFormData, Guid courseCode, Guid trainingID)
        {
            var person = this._mapper.Map<Person>(personFormData);
            var physicalAddressFormData = personFormData.PhyiscalAddress.FirstOrDefault();

            var transaction = this._repository.Context.Database.BeginTransaction();

            this._repository.People.Create(person);
            this._repository.Save();

            this._physicalAddressService.CreatePhysicalAddress(person.PersonID, physicalAddressFormData);
            this._repository.Save();

            this._registerDelegateTrainingService.CreateDelegateTraining(person.PersonID, trainingID);
            this._repository.Save();

            // after registering delegate for training remove a seat.
            var training = this._repository.Trainings.GetByCondition(t => t.CourseCode.Equals(courseCode) && t.TrainingID.Equals(trainingID), true).FirstOrDefault();
            training.AvailableSeats--;
            this._repository.Save();

            transaction.Commit(); // if can't commit due to any error in transaction, throws error to be handled globally. // does it roll back or doesn't commit at all of all "mimicked savings"?

            var personReturn = this._mapper.Map<PersonReadDTO>(person);
            return personReturn; // data to return after user is registered for training can be business specified to know what kind of route to create for 201 created status.
        }
    }
}
