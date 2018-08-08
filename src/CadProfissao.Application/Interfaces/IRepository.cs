using System.Collections.Generic;

namespace CadProfissao.Application.Interfaces
{
    public interface IRepository<T>where T : class
    {
        void Add(T item, string query);

        void Remove(int id);

        void Update(T item);

        T FindByID(int id);

        IEnumerable<T> FindAll(string query);
    }
}