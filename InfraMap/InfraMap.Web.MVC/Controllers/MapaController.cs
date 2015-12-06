﻿using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using InfraMap.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    [Autorizador]
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
            var id = Convert.ToInt32(Request.Params["id"]);
            var nome = Request.Params["colaborador"];
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
        public JsonResult RemoverColaborador()
        {
            var helper = new MapaHelper();
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            try
            {
                helper.RemoverColaborador(idMesa);
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
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            var maquina = Request.Params["maquina"];
            var tipo = Convert.ToInt32(Request.Params["tipo"]);
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
        public JsonResult RemoverMaquina()
        {
            var helper = new MapaHelper();
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            try
            {
                helper.RemoverMaquina(idMesa);
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
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            var numero = Request.Params["ramal"];
            var tipo = Convert.ToInt32(Request.Params["tipo"]);
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
        public JsonResult RemoverRamal()
        {
            var helper = new MapaHelper();
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            try
            {
                helper.RemoverRamal(idMesa);
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