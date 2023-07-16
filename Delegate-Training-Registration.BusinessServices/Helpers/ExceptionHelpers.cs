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

	public static void TrainingForCourseNullCheck(Training trainingCheck, Guid courseCode, Guid trainingID)
	{
	  if (trainingCheck == null) throw new KeyNotFoundException($"Training : {trainingID}, for course : {courseCode}, not available.");
	}

	public static void TrainingsForCourseNullCheck(IEnumerable<Training> courseTrainings, Guid courseCode)
	{
	  if (!courseTrainings.Any()) throw new KeyNotFoundException($"Trainings for course :{courseCode}, not available.");
	}
  }
}
