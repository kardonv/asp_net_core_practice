using AutoMapper;
using WebApp.BLL.DTO;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<RegisterBindingModel, UserDTO>().ForMember(x => x.Email, source => source.MapFrom(x => x.Login)) ;
        }
    }
}
