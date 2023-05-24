using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delegate_Training_Registration.DataAccess.Models
{
    public class PhysicalAddress
    {
        [Key]
        public Guid PhysicalAddressesID { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }

        // navigation props
        [ForeignKey(nameof(Person))]
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
    }
}
