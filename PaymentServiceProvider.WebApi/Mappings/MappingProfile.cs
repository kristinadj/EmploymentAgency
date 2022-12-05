using AutoMapper;
using EmploymentAgency.DTO;
using PaymentServiceProvider.WebApi.Model;

namespace PaymentServiceProvider.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentTypeService, PaymentTypeServiceDTO>();
            CreateMap<PaymentTypeServiceDTO, PaymentTypeService>();
        }
    }
}
