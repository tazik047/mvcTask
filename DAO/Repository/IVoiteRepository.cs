using DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    public interface IVoiteRepository : IRepository<Voite>
    {
        long Summary();
    }
}
