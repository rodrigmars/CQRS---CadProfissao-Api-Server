using CadProfissao.Application.Interfaces;
using System;

namespace CadProfissao.Application.Entities
{
    public class Profissional : Entity<Guid>
    {
        public Profissional(string Nome, string Email, int Idade, int TipoProfissaoId, bool Desempregado) : base(Guid.NewGuid())
        {
            this.Nome = Nome;

            this.Email = Email;

            this.Idade = Idade;

            this.Desempregado = Desempregado;

            this.TipoProfissaoId = TipoProfissaoId;
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public int Idade { get; private set; }

        public bool Desempregado { get; private set; }

        public int TipoProfissaoId { get; private set; }
    }
}
