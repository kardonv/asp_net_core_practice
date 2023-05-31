using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Interfaces
{
    public interface IDatabase
    {
        public IRepository<TodoItem> TodoItems{ get; }

        public IRepository<User> Users { get; }

        void Save();
    }
}
