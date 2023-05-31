using Delegate_Training_Registration.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delegate_Training_Registration.WebAPI.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // get
        [HttpGet]
        public ActionResult<Course> GetCourses()
        {
            return Ok();
        }

        [HttpGet("{courseCode}", Name = "GetCourse")]
        public ActionResult<Course> GetCourse(Guid courseCode)
        {
            return Ok();
        }

        // post
        public ActionResult<Course> CreateCourse(Course course)
        {
            return CreatedAtRoute(nameof(GetCourse), new { courseCode = 0 }, course);
        }
    }
}
