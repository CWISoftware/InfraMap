using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa;

namespace InfraMap.Web.MVC.Controllers
{
    public class MaquinaController : BaseController
    {
        [HttpPost]
        public JsonResult AdicionarMaquina(MaquinaPessoalModel model)
        {
            try
            {
                var service = Factory.CriarMesaService();
                var maquinaPessoal = MaquinaPessoalModelHelper.ToEntity(model);
                service.AdicionarMaquina(model.IdMesa, maquinaPessoal);
            }
            catch (MaquinaEmOutraMesaException maquina)
            {
                return Json(new { message = maquina.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { message = "true" }, JsonRequestBehavior.AllowGet);
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
            var maquina = Factory.CriarMaquinaRepositorio();
            var listaModelosMaquina = repositorio.BuscarTodos();
            var listaModelosAtualizada = listaModelosMaquina;
            for (int modelo = 0; modelo < listaModelosMaquina.Count; modelo++)
            {
                if (maquina.BuscarPorIdModelo(listaModelosMaquina[modelo].Id) == null)
                {
                    repositorio.Deletar(listaModelosMaquina[modelo]);
                    listaModelosMaquina.Remove(listaModelosMaquina[modelo]);
                }
            }

            return Json(listaModelosMaquina, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult MaquinaDoModelo(int idModelo)
        {
            var repositorio = Factory.CriarMaquinaRepositorio();
            var maquina = repositorio.BuscarPorIdModelo(idModelo);
            var name = repositorio.RetornaNomeMaquina(maquina);
            maquina.ModeloMaquina = name;

            return Json(maquina, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ConfigurarMaquina()
        {
            try
            {
                return View("ConfigurarMaquina");
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
        }

        [HttpGet]
        public ActionResult EditarMaquina()
        {
            try
            {
                return View("EditarMaquina");
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
        }

        [HttpPost]
        public JsonResult SalvaMaquina(Maquina model)
        {
            try
            {
                var service = Factory.CriarMaquinaRepositorio();

                var maquinaAdicionada = service.Adicionar(model);

                if (maquinaAdicionada != null)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }

        }

        [HttpPost]
        public JsonResult SalvaEdicaoMaquina(Maquina model)
        {
            try
            {
                if (model.ModeloMaquina.Name == null)
                    return Json(new { success = false });

                model.ModeloMaquina.Id = model.ModeloMaquina_Id.GetValueOrDefault();

                var service = Factory.CriarMaquinaRepositorio();
                var maquina = service.BuscarPorIdModelo(model.ModeloMaquina_Id.GetValueOrDefault());
                model.Id = maquina.Id;
                service.Atualizar(model);


                return Json(new { success = true });
            }

            catch (Exception e)
            {
                return ErroTratado(e);
            }

        }

        [HttpPost]
        public JsonResult SalvaEdicaoMaquinaPessoal(Maquina model)
        {
            try
            {
                if (model.ModeloMaquina.Name == null)
                    return Json(new { success = false });

                model.ModeloMaquina.Id = model.ModeloMaquina_Id.GetValueOrDefault();

                var service = Factory.CriarMaquinaRepositorio();
                var maquina = service.BuscarPorId(model.Id);
                service.Atualizar(model);


                return Json(new { success = true });
            }

            catch (Exception e)
            {
                return ErroTratado(e);
            }

        }

        [HttpPost]
        public JsonResult DeletaMaquina(Maquina model)
        {
            try
            {
                model.ModeloMaquina.Id = model.ModeloMaquina_Id.GetValueOrDefault();

                var service = Factory.CriarMaquinaRepositorio();
                var maquina = service.BuscarPorIdModelo(model.ModeloMaquina_Id.GetValueOrDefault());
                model.Id = maquina.Id;
                service.Deletar(model);


                return Json(new { success = true });
            }

            catch (Exception e)
            {
                return ErroTratado(e);
            }

        }

        [HttpGet]
        public JsonResult VerMaquina(int idMesa)
        {
            try
            {
                var service = Factory.CriarMesaRepositorio();
                var mesa = service.BuscarPorId(idMesa);
                var maquina = mesa.MaquinaPessoal;
                return Json(maquina, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }
        }

    }
}