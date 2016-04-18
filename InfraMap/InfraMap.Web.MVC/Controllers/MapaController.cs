using InfraMap.Web.MVC.Helpers;
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
    public class MapaController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string sede, int andar)
        {
            try
            {
                var sedeRepositorio = Factory.CriarSedeRepositorio();
                var andarDb = sedeRepositorio.BuscarSedePorNome(sede).Andares.FirstOrDefault(t => t.Id == andar);
                var model = andarDb;
                return View(sede + andarDb.Id, model);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
        }

        [HttpGet]
        public ActionResult MostraMesa(string sede, int andar, int mesa)
        {
            try
            {
                var sedeRepositorio = Factory.CriarSedeRepositorio();
                var andarDb = sedeRepositorio.BuscarSedePorNome(sede).Andares.FirstOrDefault(t => t.Id == andar);
                var model = andarDb;
                return View(sede + andarDb.Id, model);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
        }

        [HttpPost]
        public ActionResult RenderPartialViewSpotMesa(int id)
        {
            var mesaRepositorio = Factory.CriarMesaRepositorio();
            var mesa = mesaRepositorio.BuscarPorId(id);
            var model = new MesaModel(mesa);
            return PartialView("_SpotMesa", model);
        }

        private JsonResult ErroTratado(Exception e)
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

        public void SalvarCorDosColaboradores(int[] listaIdMesa)
        {
            var a = listaIdMesa;
            var mesaRepositorio = Factory.CriarMesaRepositorio();
            var mesa = mesaRepositorio.BuscarPorId(a.First());
            var usuarioLogado = ControleDeSessao.UsuarioLogado;
            //TODO: salvar cor para colaborador que esta na mesa
        }
    }
}