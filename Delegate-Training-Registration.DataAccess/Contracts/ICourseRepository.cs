using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.DataAccess.Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses(bool isTrackingChanges);
        Course GetCourse(Guid courseCode, bool isTrackingChanges);
    }
}
