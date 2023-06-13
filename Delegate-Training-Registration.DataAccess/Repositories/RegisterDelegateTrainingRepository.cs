using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
    public class RegisterDelegateTrainingRepository : GenericRepository<RegisterDelegateTrainings>, IRegisterDelegateTrainingRepository
    {
        public RegisterDelegateTrainingRepository(DelegateTrainingRegistrationContext context) : base(context)
        {
        }
    }
}
