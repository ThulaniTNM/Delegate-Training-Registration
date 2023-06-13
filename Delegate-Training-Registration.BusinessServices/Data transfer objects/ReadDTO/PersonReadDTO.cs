using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO
{
    public class PersonReadDTO
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string CompanyName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Dietary Dietary { get; set; }
    }
}
