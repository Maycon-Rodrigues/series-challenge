using System.Collections.Generic;

namespace SeriesChallenge.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Update(int id, T entity);

        void Delete(int id);

        int NextId();
    }
}