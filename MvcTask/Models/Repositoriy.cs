using MvcTask.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcTask.Models
{
    public class Repositoriy
    {
        private Entities db = new Entities();

        public List<Article> Articles
        {
            get
            {
                return db.Articles.ToList();
            }
        }

        public List<Review> Reviews
        {
            get
            {
                return db.Reviews.ToList();
            }
        }

        public List<Form> Forms
        {
            get
            {
                return db.Forms.ToList();
            }
        }

        public void Add<T>(T obj) where T : class
        {
            db.Entry(obj).State = System.Data.EntityState.Added;
            db.SaveChanges();
        }
        
        public List<Review> LastReviews(int count)
        {
            return Reviews.OrderBy(r => r.Date).Take(count).ToList();
        }
    }
}