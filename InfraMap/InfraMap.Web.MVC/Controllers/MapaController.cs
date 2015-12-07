﻿using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using InfraMap.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfraMap.Dominio.Mesa;

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
                var sedeRepositorio = FabricaDeModulos.CriarSedeRepositorio();
                var sedeDb = sedeRepositorio.BuscarSedePorNome(sede);
                var andar = sedeDb.Andares.FirstOrDefault(t => t.Descricao.Equals(nomeAndar));
                var model = new AndarModel(andar);
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
            var service = new MesaService(FabricaDeModulos.CriarMesaRepositorio(), FabricaDeModulos.CriarUsuarioRepositorio());
            var id = Convert.ToInt32(Request.Params["id"]);
            var nome = Request.Params["colaborador"];
            try
            {
                service.AdicionarColaborador(id, nome);
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
            var service = new MesaService(FabricaDeModulos.CriarMesaRepositorio(), FabricaDeModulos.CriarUsuarioRepositorio());
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            try
            {
                service.RemoverColaborador(idMesa);
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
            var service = new MesaService(FabricaDeModulos.CriarMesaRepositorio(), FabricaDeModulos.CriarMaquinaRepositorio());
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            var maquina = Request.Params["maquina"];
            var tipo = Convert.ToInt32(Request.Params["tipo"]);
            if (string.IsNullOrWhiteSpace(maquina))
            {
                return ThrowError(new Exception("Preencha os campos!"));
            }

            service.AdicionarMaquina(idMesa, maquina, tipo);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverMaquina()
        {
            var service = new MesaService(FabricaDeModulos.CriarMesaRepositorio(), FabricaDeModulos.CriarMaquinaRepositorio());
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            try
            {
                service.RemoverMaquina(idMesa);
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
            var service = new MesaService(FabricaDeModulos.CriarMesaRepositorio(), FabricaDeModulos.CriarRamalRepositorio());
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            var numero = Request.Params["ramal"];
            var tipo = Convert.ToInt32(Request.Params["tipo"]);
            if (string.IsNullOrWhiteSpace(numero))
            {
                return ThrowError(new Exception("Preencha os campos!"));
            }

            service.AdicionarRamal(idMesa, numero, tipo);             
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverRamal()
        {
            var service = new MesaService(FabricaDeModulos.CriarMesaRepositorio(), FabricaDeModulos.CriarRamalRepositorio());
            var idMesa = Convert.ToInt32(Request.Params["id"]);
            try
            {
                service.RemoverRamal(idMesa);
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
            var model = new MesaModel(mesa);
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