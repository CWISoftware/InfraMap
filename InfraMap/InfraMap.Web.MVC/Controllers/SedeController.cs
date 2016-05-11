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
using InfraMap.Dominio.Sede;

namespace InfraMap.Web.MVC.Controllers
{
    [Autorizador]
    public class SedeController : Controller
    {
        public ActionResult Index()
        {
            var repositorioSede = Factory.CriarSedeRepositorio();
            var listaSedes = repositorioSede.Buscar();
            return View("Index", listaSedes);
        }

        [HttpGet]
        public JsonResult PegarAndaresDasSedes()
        {
            var repositorioSede = Factory.CriarSedeRepositorio();
            var listaSedes = repositorioSede.BuscarSedesComAndares();
            return Json(listaSedes, JsonRequestBehavior.AllowGet);
        }

        public string PegarNomeSede(int idSede)
        {
            var sedeRepositorio = Factory.CriarSedeRepositorio();

            var sede = sedeRepositorio.BuscarPorId(idSede);
            return sede.Nome;
        }
    }
}