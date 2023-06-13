using AutoMapper;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.BusinessServices.Service_Contract;
using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Services
{
    public class PhysicalAddressService : IPhysicalAddressService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PhysicalAddressService(IRepositoryManager repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void CreatePhysicalAddress(Guid personID, PhysicalAddressWriteDTO physicalAddressFormData)
        {
            var physicalAddress = this._mapper.Map<PhysicalAddress>(physicalAddressFormData);
            physicalAddress.PersonID = personID;
            this._repository.PhysicalAddresses.Create(physicalAddress);
        }
    }
}
