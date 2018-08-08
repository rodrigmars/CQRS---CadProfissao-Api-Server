using CadProfissao.Application.Commands;
using CadProfissao.Application.Entities;
using CadProfissao.Application.Extensions;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Validations;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CadProfissao.Application.Handlers
{
    public class RegistraProfissionalCommandHandlerAsync : AsyncRequestHandler<ProfissionalCommand>
    {
        private readonly IProfissionalRepository _repository;
        private readonly IHandleNotification _notification;

        public RegistraProfissionalCommandHandlerAsync(IProfissionalRepository repository, IHandleNotification notification)
        {
            _repository = repository;
            _notification = notification;
        }

        protected override Task Handle(ProfissionalCommand request, CancellationToken cancellationToken)
        {
            var valida = new ProfissionalCommandValidation(request.Nome, request.Email, request.DataNascimento, request.Desempregado, request.TipoProfissaoId);

            var erros = valida.Parametros();

            if (erros.Any())
            {
                _notification.Erros = erros;

                return Unit.Task;
            }

            _repository.Add(new Profissional(request.Nome, request.Email, request.DataNascimento.VerIdade(), request.TipoProfissaoId, request.Desempregado),
                @"INSERT INTO PROFISSIONAL (ID, NOME, EMAIL, IDADE, DESEMPREGADO, TIPOPROFISSAOID) VALUES(@ID, @NOME, @EMAIL, @IDADE, @DESEMPREGADO, @TIPOPROFISSAOID)");

            return Unit.Task;
        }
    }
}