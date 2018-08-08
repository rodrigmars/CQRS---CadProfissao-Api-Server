using CadProfissao.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CadProfissao.Application.Notifications
{
    public class ProfissionalCommandNotification : IHandleNotification
    {
        public IEnumerable<string> Erros { get; set; }

        public HandlerStatus Status { get => (Erros != null) ? HandlerStatus.Falha : HandlerStatus.Sucesso; }
    }
}