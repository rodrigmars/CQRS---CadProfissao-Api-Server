using System;
using System.Text.RegularExpressions;

namespace CadProfissao.Application.Extensions
{
    public static class ExtensoresCustomizados
    {
        const string apenasTexto = "^[a-zA-Z ]+$";

        const string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                     + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                     + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        public static bool ApenasTexto(this string texto) => new Regex(apenasTexto, RegexOptions.IgnoreCase).IsMatch(texto);

        public static bool EmailValido(this string email) => new Regex(emailPattern, RegexOptions.IgnoreCase).IsMatch(email);

        public static int VerIdade(this DateTime DataNascimento)
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