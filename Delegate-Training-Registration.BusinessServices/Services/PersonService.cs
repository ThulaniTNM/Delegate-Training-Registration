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

        public PersonService(IRepositoryManager repository, IMapper mapper, IPhysicalAddressService physicalAddressService)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._physicalAddressService = physicalAddressService;
        }
        public PersonReadDTO RegisterPerson(PersonWriteDTO personFormData)
        {
            var person = this._mapper.Map<Person>(personFormData);
            var physicalAddressFormData = personFormData.PhyiscalAddress.FirstOrDefault();

            this._repository.People.Create(person);
            this._repository.Save();

            this._physicalAddressService.CreatePhysicalAddress(person.PersonID, physicalAddressFormData);
            this._repository.Save();

            var personReturn = this._mapper.Map<PersonReadDTO>(person);
            return personReturn;
        }
    }
}
