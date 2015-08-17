using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Repository;
using DAO.Model;

namespace EntityFrameworkDAO.Repository
{
    public class EntityFrameworkVoiteRepository : IVoiteRepository
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        public long Summary()
        {
            return GetAll().Select<Voite, int>(v => v.Mark).Aggregate(0L, (s, i) => s += i);
        }

        public void Add(Voite item)
        {
            _db.Entry(item).State = System.Data.EntityState.Added;
            _db.SaveChanges();
        }

        public void Edit(Voite item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Voite> GetAll()
        {
            return _db.Voites.ToList<Voite>();
        }

        public List<Voite> GetFirtNItem(int n)
        {
            throw new NotImplementedException();
        }

        public Voite FindById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Voite> Find(Func<Voite, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
