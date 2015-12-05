using InfraMap.Dominio.ModuloMesa;
using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class SaoLeopoldoController : MapaController
    {
        [HttpGet]
        public ActionResult Terceiro()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MesaAdicionarColaborador()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            string login = Request.Params["colaborador"];
            this.AdicionarColaborador(id, login);
            return Json(new { success = true });
        }
    }
}