using AutoMapper;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.BusinessServices.Helpers;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TrainingService(IRepositoryManager repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public IEnumerable<TrainingReadDTO> GetTrainings(Guid courseCode, bool isTrackingChanges)
        {
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), isTrackingChanges).FirstOrDefault();
            ExceptionHelpers.CourseNullCheck(course);

            var courseTrainings = this._repository.Trainings.GetByCondition(training => training.CourseCode.Equals(courseCode), isTrackingChanges);
            ExceptionHelpers.TrainingsForCourseNullCheck(courseTrainings, courseCode);

            var courseTrainingsReadDTO = this._mapper.Map<IEnumerable<TrainingReadDTO>>(courseTrainings);

            courseTrainingsReadDTO = courseTrainingsReadDTO.OrderBy(training => training.TrainingName);
            return courseTrainingsReadDTO;
        }

        public TrainingReadDTO GetTraining(Guid courseCode, Guid trainingId, bool isTrackingChanges)
        {
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), isTrackingChanges).FirstOrDefault();
            ExceptionHelpers.CourseNullCheck(course);

            var training = this._repository.Trainings.GetByCondition(training =>
                                                                                                                  training.CourseCode.Equals(courseCode) && training.TrainingID.Equals(trainingId),
                                                                                                                  isTrackingChanges).FirstOrDefault();

            ExceptionHelpers.TrainingForCourseNullCheck(training, courseCode);

            var trainingReadDTO = this._mapper.Map<TrainingReadDTO>(training);
            return trainingReadDTO;
        }

        public TrainingReadDTO CreateTraining(Guid courseCode, TrainingWriteDTO trainingCreateDTO)
        {
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), false).FirstOrDefault();
            ExceptionHelpers.CourseNullCheck(course);

            var training = this._mapper.Map<Training>(trainingCreateDTO);
            training.CourseCode = courseCode;

            this._repository.Trainings.Create(training);
            this._repository.Save();

            var trainingReadDTO = this._mapper.Map<TrainingReadDTO>(training);
            return trainingReadDTO;
        }

        public void DeleteTraining(Guid courseCode, Guid trainingId)
        {
            Course course = this._repository.Courses.GetByCondition(c => c.CourseCode.Equals(courseCode), false).FirstOrDefault();
            ExceptionHelpers.CourseNullCheck(course);

            Training training = this._repository.Trainings.GetByCondition(t => t.CourseCode.Equals(courseCode) && t.TrainingID.Equals(trainingId), true).FirstOrDefault();
            ExceptionHelpers.TrainingForCourseNullCheck(training, courseCode);

            this._repository.Trainings.Delete(training);
            this._repository.Save();
        }

        public void UpdateTraining(Guid courseCode, Guid trainingId, TrainingWriteDTO trainingUpdate)
        {
            Course course = this._repository.Courses.GetByCondition(c => c.CourseCode.Equals(courseCode), false).FirstOrDefault();
            ExceptionHelpers.CourseNullCheck(course);

            Training training = this._repository.Trainings.GetByCondition(t => t.CourseCode.Equals(courseCode) && t.TrainingID.Equals(trainingId), true).FirstOrDefault();
            ExceptionHelpers.TrainingForCourseNullCheck(training, courseCode);

            this._mapper.Map(trainingUpdate, training);
            this._repository.Save();
        }
    }
}
