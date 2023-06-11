using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryManager _repository;

        public PersonService(IRepositoryManager repository)
        {
            this._repository = repository;
        }
        public Person RegisterPerson(Person person)
        {
            this._repository.People.Create(person);
            this._repository.Save();
            return person;
        }
    }
}
