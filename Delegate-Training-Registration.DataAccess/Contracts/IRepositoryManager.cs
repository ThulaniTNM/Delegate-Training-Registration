using Delegate_Training_Registration.DataAccess.Data;

namespace Delegate_Training_Registration.DataAccess.Contracts
{
  public interface IRepositoryManager
  {
	public ICourseRepository Courses { get; }
	public ITrainingRepository Trainings { get; }
	public IPersonRepository People { get; }
	public IPhysicalAddressRepository PhysicalAddresses { get; }
	public IRegisterDelegateTrainingRepository RegisterDelegateTrainings { get; }
	public DelegateTrainingRegistrationContext Context { get; }
	public void Save();
  }
}
