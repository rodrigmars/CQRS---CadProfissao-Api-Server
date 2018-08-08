using CadProfissao.Application.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CadProfissao.Infra.Data.Repositories
{
    public class Repository<T> : ConnectionDataBase, IRepository<T> where T : class
    {
        public Repository(IConfiguration configuration) : base(configuration) { }

        public void Add(T obj, string query)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Execute(query, obj);
            }
        }

        public IEnumerable<T> FindAll(string query)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<T>(query).ToList();
            }
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T item)
        {
            throw new System.NotImplementedException();
        }

        public T FindByID(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
