using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delegate_Training_Registration.WebAPI.Controllers
{
  [Route("api/courses/{courseCode}/trainings")]
  [ApiController]
  public class TrainingsController : ControllerBase
  {
	private readonly ITrainingService training;

	public TrainingsController(ITrainingService training)
	{
	  this.training = training;
	}
	[HttpGet]
	public ActionResult<IEnumerable<Training>> GetTrainings(Guid courseCode)
	{
	  var trainings = this.training.GetTrainings(courseCode, false);
	  return Ok(trainings);
	}

	[HttpGet("{trainingId}", Name = "GetTraining")]
	public ActionResult<Training> GetTraining(Guid courseCode, Guid trainingId)
	{
	  var training = this.training.GetTraining(courseCode, trainingId, false);
	  return Ok(training);
	}

	[HttpPost]
	public ActionResult<TrainingWriteDTO> CreateTraining(Guid courseCode, [FromBody] TrainingWriteDTO trainingFormData)
	{
	  var training = this.training.CreateTraining(courseCode, trainingFormData);
	  return CreatedAtRoute(nameof(GetTraining), new { courseCode = courseCode, trainingId = training.TrainingID }, training);
	}

	[HttpDelete]
	public IActionResult DeleteTraining(Guid courseCode, Guid trainingId)
	{
	  this.training.DeleteTraining(courseCode, trainingId);
	  return NoContent();
	}

	[HttpPut]
	public IActionResult UpdateTraining(Guid courseCode, Guid trainingId, [FromForm] TrainingWriteDTO trainingFormData)
	{
	  this.training.UpdateTraining(courseCode, trainingId, trainingFormData);
	  return NoContent();
	}
  }
}
