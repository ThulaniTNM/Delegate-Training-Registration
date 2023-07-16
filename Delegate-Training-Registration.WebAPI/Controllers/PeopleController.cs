using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
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
        // add person data along with child resource of their address.
        [HttpPost]
        public void CreatePerson(Guid trainingID, [FromBody] PersonWriteDTO personFormData)
        {
            //var person = this._personService.RegisterPerson(personFormData, trainingID);

            // GetPerson method not existing yet, can be created through product requirement updates.
            //return CreatedAtRoute("GetPerson", new { id = person.PersonID }, person);
        }
    }
}
