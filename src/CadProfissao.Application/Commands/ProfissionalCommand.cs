using MediatR;
using System;

namespace CadProfissao.Application.Commands
{
    public class ProfissionalCommand : IRequest
    {
        public ProfissionalCommand(string Nome, string Email, DateTime DataNascimento, bool Desempregado, int TipoProfissaoId)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.DataNascimento = DataNascimento;
            this.Desempregado = Desempregado;
            this.TipoProfissaoId = TipoProfissaoId;
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public bool Desempregado { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public int TipoProfissaoId { get; private set; }

        public int CalculaIdade()
        {
            var idade = DateTime.Now.Year - DataNascimento.Year;

            if ((DataNascimento.Month > DateTime.Now.Month) ||
                (DataNascimento.Month == DateTime.Now.Month && DataNascimento.Day > DateTime.Now.Day))
            {
                idade--;
            }

            return idade;
        }
    }
}
