using MVC_TesteSimpress.Business;
using MVC_TesteSimpress.Models;
using System;
using System.Web.Mvc;

namespace SimpressTeste.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoBusiness produtoBusiness = new ProdutoBusiness();
        private CategoriaProdutoBusiness categoriaProdutoBusiness = new CategoriaProdutoBusiness();

        [HttpGet]
        public ActionResult Index()
        {
            var produtosDb = produtoBusiness.ListarTodosProdutos();
            ViewBag.Produtos = produtosDb;

            var categoriasDb = categoriaProdutoBusiness.ListarTodasCategorias();
            ViewBag.Categorias = categoriasDb;

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto()
        {
            var categoriasDb = categoriaProdutoBusiness.ListarTodasCategorias();
            ViewBag.Categorias = categoriasDb;
            return View();
        }

        [HttpPost]
        public void SalvarProduto()
        {
            var produto = new Produto();

            produto.nome = Request["nome"];
            produto.descricao = Request["descricao"];
            produto.ativo = true;
            produto.perecivel = Convert.ToBoolean(Request["perecivel"]);
            produto.idCategoria = Convert.ToInt32(Request["CategoriaID"]);

            produtoBusiness.CadastrarProduto(produto);
            Response.Redirect("/produtos");
        }

        [HttpPost]
        public void AtualizarProduto()
        {
           
            var produto = new Produto();
            produto.nome = Request["Nome"];
            produto.descricao = Request["Descricao"];
            produto.ativo = Convert.ToBoolean(Request["Ativo"]);
            produto.perecivel = Convert.ToBoolean(Request["Perecivel"]);
            produto.idCategoria = Convert.ToInt32(Request["CategoriaID"]);

            produtoBusiness.AtualizarProduto(produto);
            Response.Redirect("/produtos");
        }

        [HttpGet]
        public ActionResult EditarProduto(int id)
        {
            var produto = produtoBusiness.BuscarProduto(id);
            ViewBag.Produto = produto;

            var categoriasDb = categoriaProdutoBusiness.ListarTodasCategorias();
            ViewBag.Categorias = categoriasDb;

            return View();
        }

        [HttpGet]
        public void DeletarProduto(int id)
        {
            produtoBusiness.DeletarProduto(id);
            Response.Redirect("/produtos");
        }
    }
}