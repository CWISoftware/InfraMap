using InfraMap.Web.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class RamalController : BaseController
    {
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
    }
}