using InfraMap.Dominio.ModuloAndar;
using InfraMap.Dominio.ModuloSede;
using InfraMap.Infraestrutura.Ef.Repositorios;
using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InfraMap.Web.MVC.Controllers
{
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

        public ActionResult IrParaMapa(string descricaoAndar, int idAndar)
        {
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