using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class CourseService
    {
        private readonly IRepositoryManager _repository;

        public CourseService(IRepositoryManager repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Course> GetAllCourses(bool isTrackingChanges)
        {
            var courses = this._repository.Courses.GetAll(isTrackingChanges).OrderBy(c => c.CourseName).ToList();

            if (!courses.Any())
                throw new KeyNotFoundException("No course available");

            return courses;
        }

        public Course GetCourse(Guid courseCode, bool isTrackingChanges)
        {
            var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), isTrackingChanges).FirstOrDefault();

            if (course == null)
                throw new KeyNotFoundException($"Course : {courseCode}, not available.");

            return course;
        }

        public void CreateCourse(Course course)
        {
            this._repository.Courses.Create(course);
            this._repository.Save();
        }
    }
}
