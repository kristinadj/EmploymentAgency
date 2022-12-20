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

            CreateMap<SubscriptionPlan, SubscriptionPlanDTO>()
                .ForMember(d => d.CurrencyCode, s => s.MapFrom(x => x.Currency.Code));
        }
    }
}
