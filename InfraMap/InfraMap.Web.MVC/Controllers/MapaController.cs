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
                return View(sede + andar, andarDb);
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
                andarDb.MesaSelecionada = mesa;
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
            return PartialView("~/Views/Modais/_SpotMesa.cshtml", model);
        }

        private new JsonResult ErroTratado(Exception e)
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

        [HttpPost]
        public JsonResult SalvarCorDosColaboradores(int[] listaIdColaborador)
        {
            try
            {
                var service = Factory.CriarMesaService();
                service.SalvarCorDosColaboradores(listaIdColaborador, ControleDeSessao.UsuarioLogado.Login);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
            return Json(new { success = true });
        }

        [HttpGet]
        public JsonResult RetornaCorGerente()
        {
            try
            {
                var service = Factory.CriarUsuarioRepositorio();
                var user = service.BuscarPorLogin(ControleDeSessao.UsuarioLogado.Login);
                object color = user.Cor;
                return Json(new { message = color }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
        }

        [HttpPost]
        public JsonResult SalvaCorGerente(string color)
        {
            try
            {
                var service = Factory.CriarUsuarioRepositorio();
                var mesaservice = Factory.CriarMesaService();
                var user = service.BuscarPorLogin(ControleDeSessao.UsuarioLogado.Login);
                var coloruser = service.BuscarPorCor(color);
                var message = "";
                if (coloruser == null)
                {
                    user.Cor = color;
                    service.Atualizar(user);
                    var userlist = service.BuscarColaboradoresVinculados(user.Id);
                    mesaservice.SalvarCorDosColaboradores(userlist, ControleDeSessao.UsuarioLogado.Login);

                }
                else
                {
                    message = "O usuário " + coloruser.Nome + " já está usando esta cor!";
                }
                return Json(new { response = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
        }
    }
}