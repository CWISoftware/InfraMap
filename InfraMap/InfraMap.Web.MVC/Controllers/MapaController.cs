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
    public class MapaController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sede, int andar)
        {     
            try
            {
                var sedeRepositorio = Factory.CriarSedeRepositorio();
                var andarDb = sedeRepositorio.BuscarSedePorNome(sede).Andares.FirstOrDefault(t => t.Id == andar);
                var model = new AndarModel(andarDb);
                return View(sede + andarDb.Id, model);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }  
        }     

        [HttpPost]
        public JsonResult AdicionarColaborador(int id, string colaborador)
        {
            try
            {
                var service = Factory.CriarMesaService();
                service.AdicionarColaborador(id, colaborador);
            }
            catch(UsuarioEmOutraMesaException)
            {
                return Json(new { success = true, trocar = true });
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
            
            return Json(new { success = true, trocar = false});
        }

        [HttpPost]
        public JsonResult TrocarMesaColaborador(int id, string colaborador)
        {
            try
            {
                var service = Factory.CriarMesaService();
                service.TrocarColaborador(id, colaborador);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
            
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverColaborador(int id)
        {
            try
            {
                var service = Factory.CriarMesaService();
                service.RemoverColaborador(id);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult AdicionarMaquina(int id, string maquina, int tipo)
        {         
            if (string.IsNullOrWhiteSpace(maquina))
            {
                return ErroTratado(new Exception("Preencha os campos!"));
            }

            var service = Factory.CriarMesaService();
            service.AdicionarMaquina(id, maquina, tipo);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverMaquina(int id)
        {
            try
            {
                var service = Factory.CriarMesaService();
                service.RemoverMaquina(id);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult AdicionarRamal(int id, string ramal, int tipo)
        {      
            if (string.IsNullOrWhiteSpace(ramal))
            {
                return ErroTratado(new Exception("Preencha os campos!"));
            }

            var service = Factory.CriarMesaService();
            service.AdicionarRamal(id, ramal, tipo);             
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverRamal(int id)
        {
            try
            {
                var service = Factory.CriarMesaService();
                service.RemoverRamal(id);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }

            return Json(new { success = true });
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