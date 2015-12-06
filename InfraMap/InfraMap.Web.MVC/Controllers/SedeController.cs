using InfraMap.Dominio.ModuloAndar;
using InfraMap.Dominio.ModuloSede;
using InfraMap.Infraestrutura.Ef.Repositorios;
using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using InfraMap.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InfraMap.Web.MVC.Controllers
{
    [Autorizador]
    public class SedeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PegarAndaresDasSedes()
        {
            ISedeRepositorio repositorioSede = FabricaDeModulos.CriarSedeRepositorio();
            var listaSedes = repositorioSede.BuscarSedesComAndares();
            return Json(listaSedes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IrParaMapa()
        {
            string descricaoAndar = Request.Params["descricaoAndar"];
            int idAndar = Convert.ToInt32(Request.Params["idAndar"]);
            var andarRepositorio = FabricaDeModulos.CriarAndarRepositorio();

            var andar = andarRepositorio.BuscarAndarComMesas(idAndar);
            var andarModel = new AndarModel()
            {
                Id = andar.Id,
                Descricao = andar.Descricao                
            };

            return RedirectToAction("Terceiro","SaoLeopoldo");
        }
    }
}