using System.Collections.Generic;

namespace HomeWorkProject.Models.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T FindByID(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        List<T> Search(string term);
    }
}