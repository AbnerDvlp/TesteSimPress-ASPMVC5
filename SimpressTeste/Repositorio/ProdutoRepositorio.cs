using MVC_TesteSimpress.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MVC_TesteSimpress.Repositorio
{
    public class ProdutoRepositorio
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlconnection"];
        }

        public bool Create(Produto produto)
        {
            int retorno = 0;
            decimal ativo = 0;
            decimal perecivel = 0;

            using (SqlConnection conexao = new SqlConnection(sqlConn()))
            {
                if (produto.ativo)
                    ativo = 1;
                else
                    ativo = 0;
                if (produto.perecivel)
                    perecivel = 1;
                else
                    perecivel = 0;

                string QuerySQL = $"INSERT INTO TblProduto (Nome, Descricao, Ativo,Perecivel,CategoriaID)VALUES" +
                    $"(" +
                    $"'{produto.nome}'," +
                    $"'{produto.descricao}'," +
                    $"'{ativo}'," +
                    $"'{perecivel}'," +
                    $"'{produto.idCategoria}'" +
                    $")";

                SqlCommand comandoSQL = new SqlCommand(QuerySQL, conexao);
                comandoSQL.Connection.Open();
                retorno = comandoSQL.ExecuteNonQuery();
            }
            if (retorno == 0)
                return false;
            else
                return true;
        }

        public DataTable Read(int id)
        {
            using (SqlConnection conexao = new SqlConnection(sqlConn()))
            {
                string consultaSQL = $"SELECT * from tblProduto WHERE id ='{id}'";
                SqlCommand comandoSQL = new SqlCommand(consultaSQL, conexao);
                comandoSQL.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comandoSQL;
                DataTable tabela = new DataTable();
                adaptador.Fill(tabela);
                return tabela;
            }
        }

        public DataTable ReadAll()
        {
            using (SqlConnection conexao = new SqlConnection(sqlConn()))
            {
                string consultaSQL = "SELECT * FROM tblProduto";
                SqlCommand comandoSQL = new SqlCommand(consultaSQL, conexao);
                comandoSQL.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comandoSQL;
                DataTable tabela = new DataTable();
                adaptador.Fill(tabela);
                return tabela;
            }
        }

        public bool Update(Produto produto)
        {
            int retorno = 0;
            decimal ativo = 0;
            using (SqlConnection conexao = new SqlConnection(sqlConn()))
            {
                if (produto.ativo)
                    ativo = 1;
                else
                    ativo = 0;
                string QuerySQL = $"UPDATE tblProduto SET " +
                    $"Nome        = '{produto.nome}'," +
                    $"Descricao   = '{produto.descricao}'," +
                    $"Ativo       = '{ativo}'," +
                    $"Perecivel   = '{produto.perecivel}'," +
                    $"CategoriaID = '{produto.idCategoria}'" +
                    $"WHERE id    = '{produto.id}'; ";

                SqlCommand comandoSQL = new SqlCommand(QuerySQL, conexao);
                comandoSQL.Connection.Open();
                retorno = comandoSQL.ExecuteNonQuery();
            }
            if (retorno == 0)
                return false;
            else
                return true;
        }

        public bool Delete(int id)
        {
            int retorno = 0;
            using (SqlConnection conexao = new SqlConnection(sqlConn()))
            {
                string consultaSQL = $"DELETE FROM tblProduto WHERE id ='{id}';";

                SqlCommand comandoSQL = new SqlCommand(consultaSQL, conexao);
                comandoSQL.Connection.Open();
                retorno = comandoSQL.ExecuteNonQuery();
            }
            if (retorno == 0)
                return false;
            else
                return true;
        }
    }
}