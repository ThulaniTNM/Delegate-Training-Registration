using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO
{
    public class PersonWriteDTO
    {
        public string FirstName { get; set; }
        public string CompanyName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Dietary Dietary { get; set; }
        public ICollection<PhysicalAddressWriteDTO> PhyiscalAddress { get; set; }
    }
}
