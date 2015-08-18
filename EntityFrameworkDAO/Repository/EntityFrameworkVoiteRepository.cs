using System;
using System.Collections.Generic;
using System.Data;
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

        public double Summary()
        {
            var marks = GetAll().Select(v => v.Mark);
            return marks.Any() ? marks.Average() : 0;
        }

        public void Add(Voite item)
        {
            _db.Entry(item).State = EntityState.Added;
            _db.SaveChanges();
        }

        public void Edit(Voite item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(long id)
        {
            _db.Voites.Remove(FindById(id));
            _db.SaveChanges();
        }

        public List<Voite> GetAll()
        {
            return _db.Voites.ToList();
        }

        public List<Voite> GetFirtNItem(int n)
        {
            return GetAll().Take(n).ToList();
        }

        public Voite FindById(long id)
        {
            return _db.Voites.Find(id);
        }

        public List<Voite> Find(Func<Voite, bool> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }
    }
}
