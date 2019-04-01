using System;

namespace calc.WebApi.Reposiotry
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        bool Delete(int id);

    }
}