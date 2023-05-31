using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;
using WebApp.BLL.Interfaces;
using WebApp.BLL.Logic;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;
using WebApp.DAL.Repositories;

namespace WebApp.BLL.Services
{
    public class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRepository<User>>().To<UserRepository>();
        }
    }

    public class UserService : IUserService
    {
        IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserDTO Login(string username, string password)
        {
            User user = userRepository.Get(1);

            //var userDto mapper.Map<UserDTO>(user);

            //var isPasswordValid = PasswordHasher.IsPasswordValid(userDto, password);
            throw new NotImplementedException();
        }

        public bool Register(UserDTO user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password);

            // userRepository.Create(user);

            return true;
        }
    }
}
