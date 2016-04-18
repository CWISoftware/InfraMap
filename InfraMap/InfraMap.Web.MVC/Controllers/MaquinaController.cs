using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class MaquinaController : BaseController
    {
        [HttpPost]
        public JsonResult AdicionarMaquina(MaquinaPessoalModel model)
        {
            var service = Factory.CriarMesaService();
            var maquinaPessoal = MaquinaPessoalModelHelper.ToEntity(model);
            service.AdicionarMaquina(model.IdMesa, maquinaPessoal);
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

        [HttpGet]
        public JsonResult NomesModelosPadrao()
        {
            var repositorio = Factory.CriarModeloMaquinaRepositorio();
            var listaModelosMaquina = repositorio.BuscarTodos();

            return Json(listaModelosMaquina, JsonRequestBehavior.AllowGet);
        }
    }
}