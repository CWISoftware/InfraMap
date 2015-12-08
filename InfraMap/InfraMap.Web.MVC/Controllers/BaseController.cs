using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Web.MVC.Controllers
{
    [Autorizador]
    public class BaseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private IList<Usuario> BuscarUsuarioPeloFiltro(string term)
        {
            IUsuarioRepositorio usuario = Factory.CriarUsuarioRepositorio();
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
            var json = usuarioEncontrado.Select(usuarios => new { label = usuarios.Nome, id = usuarios.Id });
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private IList<Usuario> BuscarUsuarioPorLogin(String term)
        {
            IUsuarioRepositorio usuario = Factory.CriarUsuarioRepositorio();
            if (String.IsNullOrEmpty(term))
            {
                return usuario.Buscar();
            }
            else
            {
                return usuario.BuscarUsuariosPorLogin(term);
            }
        }

        public JsonResult UsuarioLoginAutoComplete(string term)
        {
            IList<Usuario> usuarioEncontrado = BuscarUsuarioPorLogin(term);
            var json = usuarioEncontrado.Select(usuarios => new { label = usuarios.Login });
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CarregarMapaDoUsuarioPesquisado(string nome)
        {
            var sede = Factory.CriarSedeRepositorio();
            var andar = Factory.CriarAndarRepositorio();
            var mesa = Factory.CriarMesaRepositorio();
            var user = Factory.CriarUsuarioRepositorio();

            var andarDoUsuario = andar.BuscarPorMesa(mesa.BuscarMesaPorColaborador(user.BuscarPorNome(nome).Login));
            var descricaoAndar = andarDoUsuario.Descricao;
            var nomeSede = sede.BuscarSedePorAndar(andarDoUsuario).Nome;

            string[] sedeEDescricao = { nomeSede , descricaoAndar};
            return Json(sedeEDescricao, JsonRequestBehavior.AllowGet);
        }
        
    }
}