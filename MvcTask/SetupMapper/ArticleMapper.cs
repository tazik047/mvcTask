using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBL;
using DAO.Model;
using MvcTask.Models;

namespace MvcTask.SetupMapper
{
    public static class ArticleMapper
    {
        public static void MapForPreview(int size)
        {
            AutoMapper.Mapper.CreateMap<Article, PreviewArticle>()
                .ForMember(a => a.Text,
                    map =>
                        map.MapFrom(
                            art => ArticleWorker.ReduceText(art.Text, size)));
        }

        public static void MapForEditing()
        {
            AutoMapper.Mapper.CreateMap<Article, Areas.admin.Models.Article>()
                .ForMember(a => a.Tags,
                    map => map.MapFrom(
                        art => art.Tags.Select(t => t.TagId).ToList()));
        }
    }
}