using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface ICourseService
    {
        IEnumerable<CourseReadDTO> GetAllCourses(bool isTrackingChanges);
        CourseReadDTO GetCourse(Guid courseCode, bool isTrackingChanges);
        CourseReadDTO CreateCourse(CourseWriteDTO courseCreate);
        void DeleteCourse(Guid courseCode);
        void UpdateCourse(Guid courseCode, CourseWriteDTO courseUpdate);
    }
}
