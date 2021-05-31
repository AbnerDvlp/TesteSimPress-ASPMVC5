using MVC_TesteSimpress.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MVC_TesteSimpress.Repositorio
{
    public class CategoriaProdutoRepositório
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlconnection"];
        }
        public DataTable ReadAll()
        {
            using (SqlConnection conexao = new SqlConnection(sqlConn()))
            {
                string consultaSQL = "SELECT * FROM tblCategoriaProduto";
                SqlCommand comandoSQL = new SqlCommand(consultaSQL, conexao);
                comandoSQL.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comandoSQL;
                DataTable tabela = new DataTable();
                adaptador.Fill(tabela);
                return tabela;
            }
        }
    }
}