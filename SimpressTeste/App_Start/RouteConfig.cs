using System.Web.Mvc;
using System.Web.Routing;

namespace SimpressTeste
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produtos", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "cadastrar",
              url: "{controller}/{action}/{id}",
               defaults: new { controller = "Produtos", action = "CadastrarProduto", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "atualizar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produtos", action = "AtualizarProduto", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "deletar",
                url: "{controller}/{id}/{action}",
                defaults: new { controller = "Produtos", action = "DeletarProduto", id = 0}
            );

            routes.MapRoute(
                name: "editar",
               url: "{controller}/{idProduto}/{action}",
                defaults: new { controller = "Produtos", action = "EditarProduto", id = 0 }
            );
            routes.MapRoute(
                name: "salvar",
                url: "{controller}/{action}/{idProduto}",
                defaults: new { controller = "Produtos", action = "EProduto", id = UrlParameter.Optional }
            );
        }
    }
}