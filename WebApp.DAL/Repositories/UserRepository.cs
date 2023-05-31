using WebApp.DAL.EF;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;

namespace WebApp.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
