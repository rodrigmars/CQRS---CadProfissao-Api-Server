using CadProfissao.Application.DTO;
using System.Collections.Generic;
using MediatR;

namespace CadProfissao.Application.Querys
{
    public class ListaProfissionaisQuery : IRequest<IEnumerable<ProfissionalDTO>> { }
}
