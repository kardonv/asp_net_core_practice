using WebApp.DAL.EF;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;

namespace WebApp.DAL.Repositories
{
    public class TodoItemRepository : IRepository<TodoItem>
    {
        private ApplicationContext context;

        public TodoItemRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create(TodoItem entity)
        {
            context.TodoItems.Add(entity);
        }

        public TodoItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
