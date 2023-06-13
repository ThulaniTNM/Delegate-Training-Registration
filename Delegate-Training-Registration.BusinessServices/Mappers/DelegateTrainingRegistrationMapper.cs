using AutoMapper;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.ReadDTO;
using Delegate_Training_Registration.BusinessServices.Data_transfer_objects.WriteDTO;
using Delegate_Training_Registration.DataAccess.Models;

namespace Delegate_Training_Registration.BusinessServices.Mappers
{
    public class DelegateTrainingRegistrationMapper : Profile
    {
        public DelegateTrainingRegistrationMapper()
        {
            CreateMap<Course, CourseReadDTO>().ReverseMap();
            CreateMap<Course, CourseWriteDTO>().ReverseMap();

            CreateMap<Training, TrainingReadDTO>().ReverseMap();
            CreateMap<Training, TrainingWriteDTO>().ReverseMap();

            CreateMap<Person, PersonWriteDTO>().ReverseMap();
            CreateMap<Person, PersonReadDTO>().ReverseMap();

            CreateMap<PhysicalAddress, PhysicalAddressReadDTO>().ReverseMap();
            CreateMap<PhysicalAddress, PhysicalAddressWriteDTO>().ReverseMap();
        }
    }
}
