using CadProfissao.Application.Entities;
using CadProfissao.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CadProfissao.Infra.Data.Repositories
{
    public class TipoProfissaoRepository : Repository<TipoProfissao>, ITipoProfissaoRepository
    {
        public TipoProfissaoRepository(IConfiguration configuration) : base(configuration) { }
    }
}
