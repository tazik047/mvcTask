﻿using System;
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
            var tags = new List<Tag>();
            tags.Add(new Tag { Title = ".Net" });
            tags.Add(new Tag { Title = "Java" });
            tags.Add(new Tag { Title = "C#" });
            tags.Add(new Tag { Title = "C" });
            tags.Add(new Tag { Title = "C++" });
            tags.Add(new Tag { Title = "Basic" });
            tags.ForEach(t => context.Tags.Add(t));
            context.SaveChanges();

            var rnd = new Random();
            for (int i = 1; i <= 10; i++)
            {
                var article = new Article
                {
                    Title = "Заголовок " + i,
                    Date = DateTime.Now,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu dolor ornare mi iaculis placerat vitae ac ante. Integer sed dolor non lacus auctor rutrum. Nulla facilisi. Nullam at purus vehicula diam luctus iaculis at ut dolor. Vivamus tincidunt rhoncus libero, vitae cursus elit vehicula quis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Maecenas rutrum, nibh a elementum bibendum, turpis magna faucibus odio, a interdum quam ipsum vitae turpis. Suspendisse in diam commodo, euismod odio eu, porta elit. Phasellus ac ultrices nibh, in cursus velit. Suspendisse vestibulum leo dui, quis gravida risus maximus eu. Cras vehicula in urna vel placerat.",
                    Tags = new List<Tag>
                    {
                        tags[rnd.Next(tags.Count)],
                        tags[rnd.Next(tags.Count)],
                        tags[rnd.Next(tags.Count)],
                        tags[rnd.Next(tags.Count)]
                    }.Distinct().ToList()
                };
                context.Articles.Add(article);
            }

            context.SaveChanges();
        }
    }
}
