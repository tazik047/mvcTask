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
    public class EntityFrameworkTagRepository : ITagRepository
    {
        private readonly BlogDbContext _db = BlogDbContext.Instance;

        public void Add(Tag item)
        {
            _db.Entry(item).State = EntityState.Added;
            _db.SaveChanges();
        }

        public void Edit(Tag item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(long id)
        {
            _db.Tags.Remove(FindById(id));
            _db.SaveChanges();
        }

        public List<Tag> GetAll()
        {
            return _db.Tags.ToList();
        }

        public List<Tag> GetFirtNItem(int n)
        {
            return GetAll().Take(n).ToList();
        }

        public Tag FindById(long id)
        {
            return _db.Tags.Find(id);
        }

        public List<Tag> Find(Func<Tag, bool> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }
    }
}
