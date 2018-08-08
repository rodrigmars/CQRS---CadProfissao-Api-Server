using CadProfissao.Application.DTO;
using CadProfissao.Application.Entities;
using System.Collections.Generic;

namespace CadProfissao.Application.Interfaces
{
    public interface IProfissionalRepository : IRepository<Profissional>
    {
        int Total();

        IEnumerable<ProfissionalDTO> ListaCadastrados();
    }
}
