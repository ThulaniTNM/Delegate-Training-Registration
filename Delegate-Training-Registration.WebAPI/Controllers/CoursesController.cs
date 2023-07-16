using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Microsoft.AspNetCore.Mvc;

namespace Delegate_Training_Registration.WebAPI.Controllers
{
  [Route("api/courses")]
  [ApiController]
  public class CoursesController : ControllerBase
  {
	private readonly ICourseService _courseService;

	public CoursesController(ICourseService courseService)
	{
	  this._courseService = courseService;
	}

	[HttpGet]
	public ActionResult<IEnumerable<CourseReadDTO>> GetCourses()
	{
	  var courses = this._courseService.GetAllCourses(false);
	  return Ok(courses);
	}

	[HttpGet("{courseCode}", Name = "GetCourse")]
	public ActionResult<CourseReadDTO> GetCourse(Guid courseCode)
	{
	  var course = this._courseService.GetCourse(courseCode, false);
	  return Ok(course);
	}

	[HttpPost]
	public ActionResult<CourseReadDTO> CreateCourse([FromBody] CourseWriteDTO courseFormData)
	{
	  var course = this._courseService.CreateCourse(courseFormData);
	  return CreatedAtRoute(nameof(GetCourse), new { courseCode = course.CourseCode }, course);
	}

	[HttpDelete]
	public IActionResult DeleteCourse(Guid courseCode)
	{
	  this._courseService.DeleteCourse(courseCode);
	  return NoContent();
	}

	[HttpPut("{courseCode}")]
	public IActionResult UpdateCourse(Guid courseCode, [FromBody] CourseWriteDTO courseUpdate)
	{
	  this._courseService.UpdateCourse(courseCode, courseUpdate);
	  return NoContent();
	}
  }
}
