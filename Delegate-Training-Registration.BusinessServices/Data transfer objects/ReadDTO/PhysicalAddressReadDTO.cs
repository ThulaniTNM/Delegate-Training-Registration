namespace Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO
{
    public class PhysicalAddressReadDTO
    {
        public Guid PhysicalAddressesID { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }
    }
}
