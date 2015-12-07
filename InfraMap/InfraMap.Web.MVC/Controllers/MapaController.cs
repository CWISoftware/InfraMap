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
    public class MapaController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sede, string nomeAndar)
        {     
            try
            {
                var sedeRepositorio = Factory.CriarSedeRepositorio();
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
        public JsonResult AdicionarColaborador(int id, string colaborador)
        {
            var service = Factory.CriarMesaService();
            try
            {
                service.AdicionarColaborador(id, colaborador);
            }
            catch(UsuarioEmOutraMesaException)
            {
                return Json(new { success = true, trocar = true });
            }
            catch (Exception e)
            {
                return ThrowError(e);
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
                return ThrowError(e);
            }
            
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverColaborador(int id)
        {
            var service = Factory.CriarMesaService();
            try
            {
                service.RemoverColaborador(id);
            }
            catch (Exception e)
            {
                return ThrowError(e);
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult AdicionarMaquina(int id, string maquina, int tipo)
        {
            var service = Factory.CriarMesaService();
            if (string.IsNullOrWhiteSpace(maquina))
            {
                return ThrowError(new Exception("Preencha os campos!"));
            }

            service.AdicionarMaquina(id, maquina, tipo);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverMaquina(int id)
        {
            var service = Factory.CriarMesaService();
            try
            {
                service.RemoverMaquina(id);
            }
            catch (Exception e)
            {
                return ThrowError(e);
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult AdicionarRamal(int id, string ramal, int tipo)
        {
            var service = Factory.CriarMesaService();
            if (string.IsNullOrWhiteSpace(ramal))
            {
                return ThrowError(new Exception("Preencha os campos!"));
            }

            service.AdicionarRamal(id, ramal, tipo);             
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult RemoverRamal(int id)
        {
            var service = Factory.CriarMesaService();
            try
            {
                service.RemoverRamal(id);
            }
            catch (Exception e)
            {
                return ThrowError(e);
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