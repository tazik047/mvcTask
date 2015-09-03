using DAO.Model;

namespace DAO.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        void Initialize();
    }
}
