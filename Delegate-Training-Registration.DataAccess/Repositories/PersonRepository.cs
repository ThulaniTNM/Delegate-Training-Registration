using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DelegateTrainingRegistrationContext context) : base(context)
        {
        }
    }
}
