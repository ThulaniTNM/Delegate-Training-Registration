using AutoMapper;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.BusinessServices.Helpers;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
  public class CourseService : ICourseService
  {
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public CourseService(IRepositoryManager repository, IMapper mapper)
	{
	  this._repository = repository;
	  this._mapper = mapper;
	}

	public IEnumerable<CourseReadDTO> GetAllCourses(bool isTrackingChanges)
	{
	  var courses = this._repository.Courses.GetAll(isTrackingChanges).OrderBy(c => c.CourseName).ToList();

	  ExceptionHelpers.CoursesNullCheck(courses);

	  var coursesReadDTO = this._mapper.Map<IEnumerable<CourseReadDTO>>(courses);
	  return coursesReadDTO;
	}

	public CourseReadDTO GetCourse(Guid courseCode, bool isTrackingChanges)
	{
	  var course = this._repository.Courses.GetByCondition(course => course.CourseCode.Equals(courseCode), isTrackingChanges).FirstOrDefault();

	  ExceptionHelpers.CourseNullCheck(course);

	  var courseReadDTO = this._mapper.Map<CourseReadDTO>(course);
	  return courseReadDTO;
	}

	public CourseReadDTO CreateCourse(CourseWriteDTO courseCreate)
	{
	  var course = this._mapper.Map<Course>(courseCreate);

	  this._repository.Courses.Create(course);
	  this._repository.Save();

	  var courseReadDTO = this._mapper.Map<CourseReadDTO>(course);
	  return courseReadDTO;
	}

	public void DeleteCourse(Guid courseCode)
	{
	  var course = this._repository.Courses.GetByCondition(c => c.CourseCode.Equals(courseCode), true).FirstOrDefault();

	  ExceptionHelpers.CourseNullCheck(course);

	  this._repository.Courses.Delete(course);
	  this._repository.Save();
	}

	// no need to use repo for updating, a mapping to update input with tracked entity means saving will update tracked entity.
	public void UpdateCourse(Guid courseCode, CourseWriteDTO courseUpdate)
	{
	  var course = this._repository.Courses.GetByCondition(c => c.CourseCode.Equals(courseCode), true).FirstOrDefault();

	  ExceptionHelpers.CourseNullCheck(course);

	  this._mapper.Map(courseUpdate, course);
	  this._repository.Save();
	}
  }
}
