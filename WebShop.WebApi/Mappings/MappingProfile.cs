using AutoMapper;
using EmploymentAgency.DTO;
using WebShopApp.WebApi.Model;

namespace WebShopApp.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<WebShop, WebShopDTO>();
            CreateMap<WebShopDTO, WebShop>();

            CreateMap<UserDTO, User>()
                .ForMember(d => d.UserName, s => s.MapFrom(x => x.Username));
        }
    }
}
