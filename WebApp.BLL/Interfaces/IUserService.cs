using WebApp.BLL.DTO;

namespace WebApp.BLL.Interfaces
{
    public interface IUserService
    {
        bool Register(UserDTO user);
        UserDTO Login(string username, string password);
    }
}
