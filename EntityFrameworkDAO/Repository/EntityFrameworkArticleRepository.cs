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
        private readonly BlogDbContext _db = BlogDbContext.Instance;

        public void Add(Article item)
        {
            _db.Articles.Add(item);
            _db.SaveChanges();
        }

        public void Edit(Article item)
        {
            var old = FindById(item.ArticleId);
            old.Title = item.Title;
            old.Date = item.Date;
            old.Tags.Clear();
            foreach (var tag in item.Tags)
                old.Tags.Add(tag);
            old.Text = item.Text;
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
