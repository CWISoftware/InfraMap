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
            return View(new MesaModel());
        }

        [HttpPost]
        public JsonResult MesaAdicionarColaborador()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            string nome = Request.Params["colaborador"];
            try
            {
                this.AdicionarColaborador(id, nome);
            }
            catch (Exception e)
            {
                return Json(new { success = false, msg = e.Message });
            }
            
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult MesaAdicionarMaquina()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            string maquina = Request.Params["maquina"];
            try
            {
                this.AdicionarMaquina(id, maquina);
            }
            catch (Exception e)
            {
                return Json(new { success = false, msg = e.Message });
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult MesaAdicionarRamal()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            int ramal = Convert.ToInt32(Request.Params["ramal"]);
            try
            {
                this.AdicionarRamal(id, ramal);
            }
            catch (Exception e)
            {
                return Json(new { success = false, msg = e.Message });
            }
            
            return Json(new { success = true });
        }
    }
}