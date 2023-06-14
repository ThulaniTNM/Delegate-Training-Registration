using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface IPersonService
    {
        PersonReadDTO RegisterPerson(PersonWriteDTO personCreate, Guid courseCode, Guid trainingID);
    }
}
