using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        // context for any course specific db operations.
        private readonly DelegateTrainingRegistrationContext context;

        public CourseRepository(DelegateTrainingRegistrationContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Course> GetAllCourses(bool isTrackingChanges)
        {
            var courses = this.GetAll(isTrackingChanges).OrderBy(c => c.CourseName).ToList();
            return courses;
        }

        public Course GetCourse(Guid courseCode, bool isTrackingChanges)
        {
            var course = this.GetByCondition(course => course.CourseCode.Equals(courseCode), isTrackingChanges).FirstOrDefault();
            return course;
        }

        public void CreateCourse(Course course)
        {
            this.Create(course);
        }
    }
}
