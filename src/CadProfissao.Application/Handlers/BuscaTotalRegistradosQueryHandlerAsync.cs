using System.Threading;
using System.Threading.Tasks;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Querys;
using MediatR;

namespace CadProfissao.Application.Handlers
{
    public class BuscaTotalRegistradosQueryHandlerAsync : IRequestHandler<Query, int>
    {
        private readonly IProfissionalRepository _repository;

        public BuscaTotalRegistradosQueryHandlerAsync(IProfissionalRepository repository) => _repository = repository;

        public Task<int> Handle(Query request, CancellationToken cancellationToken) => Task.FromResult(_repository.Total());
    }
}