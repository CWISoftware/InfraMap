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
            var usuario = Factory.CriarUsuarioRepositorio();
            return string.IsNullOrEmpty(term) ? usuario.Buscar() : usuario.BuscarListaPorNome(term);
        }

        public JsonResult UsuarioAutoComplete(string term)
        {
            var usuarioEncontrado = BuscarUsuarioPeloFiltro(term);
            var json = usuarioEncontrado.Select(usuarios => new { label = usuarios.Nome, id = usuarios.Id });
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private IList<Usuario> BuscarUsuarioPorLogin(string term)
        {
            var usuario = Factory.CriarUsuarioRepositorio();
            return string.IsNullOrEmpty(term) ? usuario.Buscar() : usuario.BuscarUsuariosPorLogin(term);
        }

        public JsonResult UsuarioLoginAutoComplete(string term)
        {
            var usuarioEncontrado = BuscarUsuarioPorLogin(term);
            var json = usuarioEncontrado.Select(usuarios => new { label = usuarios.Login });
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CarregarMapaDoUsuarioPesquisado(string nome)
        {
            try
            {
                var sede = Factory.CriarSedeRepositorio();
                var andar = Factory.CriarAndarRepositorio();
                var mesa = Factory.CriarMesaRepositorio();
                var user = Factory.CriarUsuarioRepositorio();

                var login = user.BuscarPorNome(nome).Login;
                var mesaDoUsuario = mesa.BuscarMesaPorColaborador(login);
                var andarDoUsuario = andar.BuscarPorMesa(mesaDoUsuario);
                var descricaoAndar = andarDoUsuario.Descricao;
                var nomeSede = sede.BuscarSedePorAndar(andarDoUsuario).Nome;

                return Json(new { sede = nomeSede, descricao = descricaoAndar });
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json(new { Message = e.Message });
            }
        }
    }
}