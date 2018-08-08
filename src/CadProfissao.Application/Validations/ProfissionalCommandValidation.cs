using System;
using CadProfissao.Application.Commands;
using CadProfissao.Application.Extensions;
using System.Collections.Generic;

namespace CadProfissao.Application.Validations
{
    public class ProfissionalCommandValidation : ProfissionalCommand
    {
        public ProfissionalCommandValidation(string Nome, string Email, DateTime DataNascimento, bool Desempregado, int TipoProfissaoId) :
            base(Nome, Email, DataNascimento, Desempregado, TipoProfissaoId)
        { }

        public IEnumerable<string> Parametros()
        {
            //Nome
            if (string.IsNullOrEmpty(Nome))
            {
                yield return "Informe um Nome.";
            }
            else
            {
                if (Nome.Length >= 250)
                {
                    yield return "O Nome deve ter no máximo 250 caracteres.";
                }

                if (!Nome.ApenasTexto())
                {
                    yield return "Informe apenas caracteres válidos para o Nome.";
                }
            }

            //Email
            if (string.IsNullOrEmpty(Email))
            {
                yield return "Informe um Email.";
            }
            else
            {
                if (!Email.EmailValido())
                {
                    yield return "Informe uma conta de e-mail válida";
                }

                if (Email.Length >= 150)
                {
                    yield return "O e-mail deve ter no máximo 150 caracteres.";
                }
            }

            //DataNascimento
            if (DataNascimento == default(DateTime))
            {
                yield return "Data de nascimento não permitida.";
            }
            else
            {
                if (DataNascimento.Year >= DateTime.Now.Year)
                {
                    yield return "Informe uma data de nascimento válida.";
                }

                if (DataNascimento.VerIdade() <= 18)
                {
                    yield return "Idade não permitida para este cadastro. O profissional deve ter no mínimo 18 anos.";
                }
            }
        }
    }
}