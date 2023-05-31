using WebApp.DAL.EF;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;

namespace WebApp.DAL.Repositories
{
    public class Database : IDatabase
    {
        private ApplicationContext context;
        private UserRepository userRepository;
        private TodoItemRepository todoItemRepository;

        public Database(string connectionString)
        {
            context = new ApplicationContext(connectionString);
        }

        public IRepository<TodoItem> TodoItems
        {
            get
            {
                if (todoItemRepository == null)
                    todoItemRepository = new TodoItemRepository(context);

                return todoItemRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {

                if (userRepository == null)
                    userRepository = new UserRepository(context);

                return userRepository;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
