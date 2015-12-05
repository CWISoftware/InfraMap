using InfraMap.Dominio.ModuloAndar;
using InfraMap.Dominio.ModuloSede;
using InfraMap.Infraestrutura.Ef.Repositorios;
using InfraMap.Web.MVC.Helpers;
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
            var listaSedes = repositorioSede.BuscarSedesComAndares().Select(s => new { id = s.Id, andares = new { } });
            return Json(listaSedes,JsonRequestBehavior.AllowGet);
        }
    }
}