using CadProfissao.Application.Entities;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Querys;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CadProfissao.Application.DTO;

namespace CadProfissao.Application.Handlers
{
    public class ListaCadastradosQueryHandlerAsync : IRequestHandler<ListaProfissionaisQuery, IEnumerable<ProfissionalDTO>>
    {
        private readonly IProfissionalRepository _repository;

        public ListaCadastradosQueryHandlerAsync(IProfissionalRepository repository) => _repository = repository;

        public Task<IEnumerable<ProfissionalDTO>> Handle(ListaProfissionaisQuery request, CancellationToken cancellationToken)
        {
            var lista = _repository.ListaCadastrados();

            return Task.FromResult(lista);
        }
    }
}
