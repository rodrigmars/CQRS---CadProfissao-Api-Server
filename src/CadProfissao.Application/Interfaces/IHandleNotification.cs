using System.Collections.Generic;

namespace CadProfissao.Application.Interfaces
{
    public enum HandlerStatus
    {
        Sucesso,
        Falha
    }

    public interface IHandleNotification
    {
        IEnumerable<string> Erros { get; set; }

        HandlerStatus Status { get; }
    }
}
