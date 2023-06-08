using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
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
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), isTrackingChanges);

            if (course == null)
                throw new KeyNotFoundException($"Course :{courseCode}, not available");

            var courseTrainings = this._repository.Trainings.GetByCondition(training => training.CourseCode.Equals(courseCode), isTrackingChanges);

            if (!courseTrainings.Any())
                throw new KeyNotFoundException($"Trainings for course :{courseCode}, not available.");

            return courseTrainings.OrderBy(training => training.TrainingName);
        }

        public Training GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges)
        {
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), isTrackingChanges);

            if (course == null)
                throw new KeyNotFoundException($"Course :{courseCode}, not available");

            var training = this._repository.Trainings.GetByCondition(training =>
                                                                                                                  training.CourseCode.Equals(courseCode) && training.TrainingID.Equals(trainingId),
                                                                                                                  isTrackingChanges).FirstOrDefault();

            if (training == null)
                throw new KeyNotFoundException($"Training : {trainingId}, for course : {courseCode}, not available.");

            return training;
        }

        public void CreateTraining(Guid courseCode, TrainingWriteDTO trainingDTO)
        {
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), false).FirstOrDefault();
            if (course == null)
                throw new KeyNotFoundException($"Course : {courseCode}, not available.");

            trainingDTO.CourseCode = courseCode;
            this._repository.Trainings.Create(trainingDTO);
            this._repository.Save();
        }

        public void DeleteTraining(Guid courseCode, Guid trainingId)
        {
            Training training = this.GetTraining(courseCode, trainingId, false);
            this._repository.Trainings.Delete(training);
            this._repository.Save();
        }

        public void UpdateTraining(Guid courseCode, Guid trainingId, Training trainingUpdate)
        {
            if (trainingUpdate == null)
                throw new ArgumentNullException("Training changes empty");

            var training = this.GetTraining(courseCode, trainingId, true);

            // use dto for updates.
            training.TrainingName = trainingUpdate.TrainingName;
            training.TrainingVenue = trainingUpdate.TrainingVenue;
            training.TrainingCost = trainingUpdate.TrainingCost;
            training.TrainingDate = trainingUpdate.TrainingDate;
            training.TrainingRegistrationClosingDate = trainingUpdate.TrainingRegistrationClosingDate;
            training.AvailableSeats = trainingUpdate.AvailableSeats;

            this._repository.Save();
        }
    }
}
