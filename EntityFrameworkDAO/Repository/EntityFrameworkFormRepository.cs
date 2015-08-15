using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAO.Model;
using DAO.Repository;

namespace EntityFrameworkDAO.Repository
{
    public class EntityFrameworkFormRepository : IFormRepository
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        public void Add(Form item)
        {
            _db.Forms.Add(item);
            _db.SaveChanges();
        }

        public void Edit(Form item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Forms.Remove(FindById(id));
        }

        public List<Form> GetAll()
        {
            return _db.Forms.ToList();
        }

        public List<Form> GetFirtNItem(int n)
        {
            return GetAll().Take(n).ToList();
        }

        public Form FindById(int id)
        {
            return _db.Forms.Find(id);
        }

        public List<Form> Find(Func<Form, bool> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }
    }
}
