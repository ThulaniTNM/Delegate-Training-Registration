using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Helpers
{
    public static class ExceptionHelpers
    {
        public static void CourseNullCheck(Course courseCheck)
        {
            if (courseCheck == null) throw new KeyNotFoundException($"Course : {courseCheck.CourseCode}, not available.");
        }

        public static void CoursesNullCheck(IEnumerable<Course> coursesCheck)
        {
            if (!coursesCheck.Any()) throw new KeyNotFoundException("No course available");
        }
    }
}
