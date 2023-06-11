using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delegate_Training_Registration.WebAPI.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            this._personService = personService;
        }
        // can add addtional features of other crud operations if requirements changes.
        [HttpPost]
        public ActionResult<Person> CreatePerson([FromBody] Person personFormData)
        {
            var person = this._personService.RegisterPerson(personFormData);

            // GetPerson method not existing yet, can be created through product requirement updates.
            return CreatedAtRoute("GetPerson", new { id = person.PersonID }, person);
        }
    }
}
