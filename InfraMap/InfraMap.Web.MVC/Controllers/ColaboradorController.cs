using InfraMap.Dominio.Mesa;
using InfraMap.Web.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class ColaboradorController : BaseController
    {
        [HttpPost]
        public JsonResult AdicionarColaborador(int id, string colaborador)
        {
            try
            {
                var service = Factory.CriarMesaService();
                service.AdicionarColaborador(id, colaborador);
            }
            catch (UsuarioEmOutraMesaException)
            {
                return Json(new { success = true, trocar = true });
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }

            return Json(new { success = true, trocar = false });
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
    }
}