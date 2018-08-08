
using CadProfissao.Application.DTO;
using CadProfissao.Application.Entities;
using CadProfissao.Application.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CadProfissao.Infra.Data.Repositories
{
    public class ProfissionalRepository : Repository<Profissional>, IProfissionalRepository
    {
        public ProfissionalRepository(IConfiguration configuration) : base(configuration) { }

        public int Total()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();

                return db.ExecuteScalar<int>(@"SELECT COUNT(*) FROM PROFISSIONAL WITH (NOLOCK)");
            }
        }

        public IEnumerable<ProfissionalDTO> ListaCadastrados()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT P.NOME, P.EMAIL, P.IDADE, P.DESEMPREGADO, TP.DESCRICAO AS PROFISSAO FROM PROFISSIONAL P WITH (NOLOCK) 
                            INNER JOIN TIPOPROFISSAO TP WITH (NOLOCK) ON P.TIPOPROFISSAOID = TP.ID";

                return db.Query<ProfissionalDTO>(sql).ToList();
            }
        }
    }
}
