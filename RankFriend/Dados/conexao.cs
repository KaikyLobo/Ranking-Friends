using MySql.Data.MySqlClient;
using System.Configuration;

namespace RankingAmigos.Dados
{
    public class Conexao
    {
        public MySqlConnection CriarConexao()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["RankingAmigos"].ConnectionString;

            return new MySqlConnection(connectionString);
        }
    }
}