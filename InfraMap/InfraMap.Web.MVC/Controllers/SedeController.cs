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

        public string PegarNomeSede()
        {
            int idSede = Convert.ToInt32(Request.Params["idSede"]);
            var sedeRepositorio = FabricaDeModulos.CriarSedeRepositorio();

            var sede = sedeRepositorio.BuscarPorId(idSede);
            return sede.Nome;
        }
    }
}