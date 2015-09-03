using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;

namespace EntityFrameworkDAO
{
    class BlogDbContext : DbContext
    {
        private static readonly  BlogDbContext instance = new BlogDbContext();

        public BlogDbContext()
            : base("BlogDbContext")
        {
            Database.SetInitializer(new BlogDbInitializer());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Voite> Voites { get; set; }
        public DbSet<User> Users { get; set; } 

        public static BlogDbContext Instance
        {
            get { return instance; }
        }
    }
}
