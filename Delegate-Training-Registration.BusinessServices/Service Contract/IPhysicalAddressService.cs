using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;

namespace Delegate_Training_Registration.BusinessServices.Service_Contract
{
    public interface IPhysicalAddressService
    {
        public void CreatePhysicalAddress(Guid personID, PhysicalAddressWriteDTO physicalAddressFormData);
    }
}
