using System;
using System.Collections.Generic;

namespace DAO.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Edit(T item);
        void Delete(int id);
        
        List<T> GetAll();
        List<T> GetFirtNItem(int n);
        T FindById(int id);

        List<T> Find(Func<T, bool> predicate);
    }
}
