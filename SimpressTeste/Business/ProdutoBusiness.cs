using MVC_TesteSimpress.Models;
using MVC_TesteSimpress.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;

namespace MVC_TesteSimpress.Business
{
    public class ProdutoBusiness
    {
        public void CadastrarProduto(Produto produto)
        {
            ProdutoRepositorio novoProduto = new ProdutoRepositorio();
            novoProduto.Create(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            ProdutoRepositorio novoProduto = new ProdutoRepositorio();
            novoProduto.Create(produto);
        }

        public void DeletarProduto(int id)
        {
            ProdutoRepositorio novoProduto = new ProdutoRepositorio();
            novoProduto.Delete(id);
        }

        public Produto BuscarProduto(int id)
        {
            Produto produto = new Produto();
            ProdutoRepositorio produtoDb = new ProdutoRepositorio();
            foreach (DataRow linha in produtoDb.Read(id).Rows)
            {
                produto.id = Convert.ToInt32(linha["id"]);
                produto.nome = Convert.ToString(linha["Nome"]);
                produto.descricao = Convert.ToString(linha["Descricao"]);
                produto.ativo = Convert.ToBoolean(linha["Ativo"]);
                produto.perecivel = Convert.ToBoolean(linha["Perecivel"]);
                produto.idCategoria = Convert.ToInt32(linha["CategoriaID"]);
            }

            return produto;
        }

        public List<Produto> ListarTodosProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            ProdutoRepositorio produtosDb = new ProdutoRepositorio();
            foreach (DataRow linha in produtosDb.ReadAll().Rows)
            {
                Produto produto = new Produto();
                produto.id = Convert.ToInt32(linha["id"]);
                produto.nome = Convert.ToString(linha["Nome"]);
                produto.descricao = Convert.ToString(linha["Descricao"]);
                produto.ativo = Convert.ToBoolean(linha["Ativo"]);
                produto.perecivel = Convert.ToBoolean(linha["Perecivel"]);
                produto.idCategoria = Convert.ToInt32(linha["CategoriaID"]);

                produtos.Add(produto);
            }
            return produtos;
        }
    }
}