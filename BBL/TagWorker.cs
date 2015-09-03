using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using DAO.Repository;

namespace BBL
{
    public static class TagWorker
    {
        public static List<Tag> FindTagsById(ITagRepository repo, List<long> ids)
        {
            return repo.Find(t => ids.Any(id => id == t.TagId)).ToList();
        }
    }
}
