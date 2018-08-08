using CadProfissao.Application.Entities;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Querys;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CadProfissao.Application.Handlers
{
    public class ListaTipoProfissaoQueryHandlerAsync : IRequestHandler<ListaTipoProfissaoQuery, IEnumerable<TipoProfissao>>
    {
        private readonly ITipoProfissaoRepository _repository;

        public ListaTipoProfissaoQueryHandlerAsync(ITipoProfissaoRepository repository) => _repository = repository;

        public Task<IEnumerable<TipoProfissao>> Handle(ListaTipoProfissaoQuery request, CancellationToken cancellationToken)
        {
            var lista = _repository.FindAll(@"SELECT * FROM TIPOPROFISSAO WITH (NOLOCK)");

            return Task.FromResult(lista);
        }
    }
}
