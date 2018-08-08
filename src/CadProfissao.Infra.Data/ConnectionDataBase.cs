using Microsoft.Extensions.Configuration;

namespace CadProfissao.Infra.Data
{
    public class ConnectionDataBase
    {
        protected string ConnectionString;

        public ConnectionDataBase(IConfiguration Configuration)
        {
            ConnectionString = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
