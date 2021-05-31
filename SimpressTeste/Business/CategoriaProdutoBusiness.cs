using MVC_TesteSimpress.Models;
using MVC_TesteSimpress.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;

namespace MVC_TesteSimpress.Business
{
    public class CategoriaProdutoBusiness
    {
        public List<Categoria> ListarTodasCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            CategoriaProdutoRepositório categoriasDb = new CategoriaProdutoRepositório();
            foreach (DataRow linha in categoriasDb.ReadAll().Rows)
            {
                Categoria categoria = new Categoria();
                categoria.id = Convert.ToInt32(linha["id"]);
                categoria.nome = Convert.ToString(linha["Nome"]);
                categoria.descricao = Convert.ToString(linha["Descricao"]);
                categoria.ativo = Convert.ToBoolean(linha["Ativo"]);

                categorias.Add(categoria);
            }
            return categorias;
        }
    }
}