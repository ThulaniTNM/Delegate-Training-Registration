using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepositoryManager _repository;

        public TrainingService(IRepositoryManager repository)
        {
            this._repository = repository;
        }
        public IEnumerable<Training> GetTrainings(Guid courseCode, bool isTrackingChanges)
        {
            var courseTrainings = this._repository.Trainings.GetByCondition(training => training.CourseCode.Equals(courseCode), isTrackingChanges);

            if (!courseTrainings.Any())
                throw new KeyNotFoundException($"Trainings for course :{courseCode}, not available.");

            return courseTrainings.OrderBy(training => training.TrainingName);
        }

        public Training GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges)
        {
            var courseTrainingsCheck = this._repository.Trainings.GetByCondition(training => training.CourseCode.Equals(courseCode), isTrackingChanges);

            if (!courseTrainingsCheck.Any())
                throw new KeyNotFoundException($"Trainings for course :{courseCode}, not available.");

            var courseTrainings = this._repository.Trainings.GetByCondition(training =>
                                                                                                                    training.CourseCode.Equals(courseCode) && training.TrainingID.Equals(trainingId),
                                                                                                                    isTrackingChanges);

            var training = courseTrainings.FirstOrDefault();
            if (training == null)
                throw new KeyNotFoundException($"Training : {trainingId}, not available.");

            return training;
        }

        public void CreateTraining(Guid courseCode, Training training)
        {
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), false).FirstOrDefault();
            if (course == null)
                throw new KeyNotFoundException($"Course : {courseCode}, not available.");

            training.CourseCode = courseCode;
            this._repository.Trainings.Create(training);
        }
    }
}
