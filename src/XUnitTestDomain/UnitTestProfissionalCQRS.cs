using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CadProfissao.Application.Commands;
using CadProfissao.Application.Entities;
using CadProfissao.Application.Handlers;
using CadProfissao.Application.Interfaces;
using CadProfissao.Application.Notifications;
using MediatR;
using Moq;
using Xunit;

namespace XUnitTestDomain
{
    public class UnitTestProfissionalCQRS
    {
        private readonly IMediator _mediator;
        private readonly IHandleNotification _notification;

        public UnitTestProfissionalCQRS()
        {
            var mockProfissionalRepository = new Mock<IProfissionalRepository>();

            mockProfissionalRepository.Setup(x => x.Add(It.IsAny<Profissional>(), It.IsAny<string>()));

            var serviceProvider = new ServiceCollection()
                .AddMediatR(typeof(RegistraProfissionalCommandHandlerAsync))
                .AddScoped<IHandleNotification, ProfissionalCommandNotification>()
                .AddSingleton(mockProfissionalRepository.Object)
                .BuildServiceProvider();

            _mediator = serviceProvider.GetService(typeof(IMediator)) as IMediator;

            _notification = serviceProvider.GetService(typeof(IHandleNotification)) as IHandleNotification;
        }

        [Fact]
        public async Task NotificaErrosEntradaDeParâmetrosInválidos()
        {
            await _mediator.Send(new ProfissionalCommand("Alícia Melissa. Laura Gonçalves", "aaliciamelissa@@abdalathomaz..adv.br", default(DateTime), true, 2));

            Assert.True(_notification.Status == HandlerStatus.Falha);

            Assert.True(_notification.Erros.Any());

            Assert.Collection(_notification.Erros,
                item => Assert.Equal("INFORME APENAS CARACTERES VÁLIDOS PARA O NOME.", item.ToUpper()),
                item => Assert.Equal("INFORME UMA CONTA DE E-MAIL VÁLIDA", item.ToUpper()),
                item => Assert.Equal("DATA DE NASCIMENTO NÃO PERMITIDA.", item.ToUpper())
            );
        }
    }
}
