using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface IPersonService
    {
        Person RegisterPerson(Person person);
    }
}
