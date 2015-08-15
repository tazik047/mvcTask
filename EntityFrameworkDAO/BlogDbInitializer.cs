using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;

namespace EntityFrameworkDAO
{
    class BlogDbInitializer : DropCreateDatabaseIfModelChanges<BlogDbContext>
    {

        protected override void Seed(BlogDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                context.Articles.Add(new Article
                {
                    Title = "Заголовок " + i,
                    Date = DateTime.Now,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu dolor ornare mi iaculis placerat vitae ac ante. Integer sed dolor non lacus auctor rutrum. Nulla facilisi. Nullam at purus vehicula diam luctus iaculis at ut dolor. Vivamus tincidunt rhoncus libero, vitae cursus elit vehicula quis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Maecenas rutrum, nibh a elementum bibendum, turpis magna faucibus odio, a interdum quam ipsum vitae turpis. Suspendisse in diam commodo, euismod odio eu, porta elit. Phasellus ac ultrices nibh, in cursus velit. Suspendisse vestibulum leo dui, quis gravida risus maximus eu. Cras vehicula in urna vel placerat."
                });
            }

            context.SaveChanges();
        }
    }
}
