using CadProfissao.Application.Entities;
using System.Collections.Generic;
using MediatR;

namespace CadProfissao.Application.Querys
{
    public class ListaTipoProfissaoQuery : IRequest<IEnumerable<TipoProfissao>> { }
}
