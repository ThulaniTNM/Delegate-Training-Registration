using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class CourseService : ICourseService
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

        public void DeleteCourse(Guid courseCode)
        {
            var course = this.GetCourse(courseCode, false);
            this._repository.Courses.Delete(course);
            this._repository.Save();
        }

        public void UpdateCourse(Guid courseCode, Course courseUpdate)
        {
            if (courseUpdate == null) // dto might have annotations to prevent null input.
                throw new ArgumentNullException($"Course changes empty");

            var course = this.GetCourse(courseCode, true);

            // update via automapper binding dto changes to tracked entity.
            course.CourseName = courseUpdate.CourseName;
            course.CourseDescription = courseUpdate.CourseDescription;

            this._repository.Save();
        }
    }
}
