using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAO.Model;
using DAO.Repository;

namespace EntityFrameworkDAO.Repository
{
    public class EntityFrameworkArticleRepository : IArticleRepositry
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        public void Add(Article item)
        {
            _db.Articles.Add(item);
            _db.SaveChanges();
        }

        public void Edit(Article item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(long id)
        {
            _db.Articles.Remove(FindById(id));
            _db.SaveChanges();
        }

        public List<Article> GetAll()
        {
            return _db.Articles.ToList();
        }

        public List<Article> GetFirtNItem(int n)
        {
            return GetAll().Take(n).ToList();
        }

        public Article FindById(long id)
        {
            return _db.Articles.Find(id);
        }

        public List<Article> Find(Func<Article, bool> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }
    }
}
