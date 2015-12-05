using InfraMap.Dominio.ModuloUsuario;
using InfraMap.Dominio.Repositorio;
using InfraMap.Web.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private IList<Usuario> BuscarUsuarioPeloFiltro(String term)
        {
            IUsuarioRepositorio usuario = FabricaDeModulos.CriarUsuarioRepositorio();
            if (String.IsNullOrEmpty(term))
            {
                return usuario.Buscar();
            }
            else
            {
                return usuario.BuscarListaPorNome(term);
            }
        }

        public JsonResult UsuarioAutoComplete(string term)
        {
            IList<Usuario> usuarioEncontrado = BuscarUsuarioPeloFiltro(term);
            var json = usuarioEncontrado.Select(usuarios => new { label = usuarios.Nome });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}