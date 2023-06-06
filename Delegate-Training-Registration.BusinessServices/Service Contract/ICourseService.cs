using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses(bool isTrackingChanges);
        Course GetCourse(Guid courseCode, bool isTrackingChanges);
        void CreateCourse(Course course);

        void DeleteCourse(Guid courseCode);
    }
}
