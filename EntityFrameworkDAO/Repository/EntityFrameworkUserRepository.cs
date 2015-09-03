using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using DAO.Repository;

namespace EntityFrameworkDAO.Repository
{
    public class EntityFrameworkUserRepository : IUserRepository
    {
        private readonly BlogDbContext _db = BlogDbContext.Instance;

        public void Initialize()
        {
            if (!_db.Database.Exists())
            {
                // Создание базы данных SimpleMembership без схемы миграции Entity Framework
                ((IObjectContextAdapter)_db).ObjectContext.CreateDatabase();
            }
        }

        public void Add(User item)
        {
            throw new NotImplementedException();
        }

        public void Edit(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<User> GetFirtNItem(int n)
        {
            throw new NotImplementedException();
        }

        public User FindById(long id)
        {
            throw new NotImplementedException();
        }

        public List<User> Find(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
