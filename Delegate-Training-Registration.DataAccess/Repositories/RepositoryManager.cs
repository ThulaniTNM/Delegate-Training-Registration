using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DelegateTrainingRegistrationContext _context;
        public ICourseRepository Courses { get; private set; }
        public ITrainingRepository Trainings { get; private set; }

        public RepositoryManager(DelegateTrainingRegistrationContext context)
        {
            this._context = context;
            Courses = new CourseRepository(context);
            Trainings = new TrainingRepository(context);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}
