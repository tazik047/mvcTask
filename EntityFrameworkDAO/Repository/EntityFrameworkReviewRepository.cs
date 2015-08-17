using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAO.Model;
using DAO.Repository;

namespace EntityFrameworkDAO.Repository
{
    public class EntityFrameworkReviewRepository : IReviewRepository
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        public void Add(Review item)
        {
            _db.Reviews.Add(item);
            _db.SaveChanges();
        }

        public void Edit(Review item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Reviews.Remove(FindById(id));
            _db.SaveChanges();
        }

        public List<Review> GetAll()
        {
            return _db.Reviews.ToList();
        }

        public List<Review> GetFirtNItem(int n)
        {
            return GetAll().Take(n).ToList();
        }

        public Review FindById(long id)
        {
            return _db.Reviews.Find(id);
        }

        public List<Review> Find(Func<Review, bool> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }
    }
}
