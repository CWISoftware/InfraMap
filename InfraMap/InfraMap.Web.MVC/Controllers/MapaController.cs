using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloRamal;
using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using InfraMap.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class MapaController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sede, string nomeAndar)
        {     
            try
            {
                var helper = new MapaHelper();
                var model = helper.BuscarAndarPorSede(sede, nomeAndar);
                return View(sede + nomeAndar, model);
            }
            catch (Exception e)
            {
                return ThrowError(e);
            }  
        }

        [HttpPost]
        public JsonResult AdicionarColaborador()
        {
            var helper = new MapaHelper();
            int id = Convert.ToInt32(Request.Params["id"]);
            string nome = Request.Params["colaborador"];
            try
            {
                helper.AdicionarColaborador(id, nome);
            }
            catch (Exception e)
            {
                return ThrowError(e);
            }
            
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult AdicionarMaquina()
        {
            var helper = new MapaHelper();
            int idMesa = Convert.ToInt32(Request.Params["id"]);
            string maquina = Request.Params["maquina"];
            string tipo = Request.Params["tipo"];
            try
            {
                helper.AdicionarMaquina(idMesa, maquina, tipo);
            }
            catch (Exception e)
            {
                return ThrowError(e);
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult AdicionarRamal()
        {
            var helper = new MapaHelper();
            int idMesa = Convert.ToInt32(Request.Params["id"]);
            string numero = Request.Params["ramal"];
            string tipo = Request.Params["tipo"];
            try
            {
                helper.AdicionarRamal(idMesa, numero, tipo);
            }
            catch (Exception e)
            {
                return ThrowError(e);
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult RenderPartialViewSpotMesa()
        {
            var id = Convert.ToInt32(Request.Params["id"]);
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var mesa = mesaRepositorio.BuscarPorId(id);
            var model = MesaModelHelper.EntidadeParaModel(mesa);
            return PartialView("_SpotMesa", model);
        }

        private JsonResult ThrowError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Json(new { Message = e.Message });
        }

        private int ContarMesasVazias(List<MesaModel> mesas)
        {
            return mesas.Count(m => !m.TemColaborador && !m.TemMaquina);
        }

        private int ContarEstacoesDisponiveis(List<MesaModel> mesas)
        {
            return mesas.Count(m => !m.TemColaborador && m.TemMaquina);
        }
    }
}