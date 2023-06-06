namespace Delegate_Training_Registration.DataAccess.Contracts
{
    public interface IRepositoryManager
    {
        public ICourseRepository Courses { get; }
        public ITrainingRepository Trainings { get; }
        public void Save();
    }
}
