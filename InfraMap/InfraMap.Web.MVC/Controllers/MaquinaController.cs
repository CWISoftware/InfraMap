using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa;
using InfraMap.Web.MVC.Seguranca;

namespace InfraMap.Web.MVC.Controllers
{
    [Autorizador]
    public class MaquinaController : BaseController
    {
        [HttpGet]
        public ActionResult ListarMaquinas()
        {
            var repositorio = Factory.CriarMaquinaPessoalRepositorio();
            var model = new ListaMaquinaModel()
            {
                Maquinas = repositorio.BuscarTodas()
            };

            return View("ListagemMaquinas", model);
        }

        [HttpGet]
        public ActionResult AdicionarModeloMaquina()
        {
            return View("AdicionarModeloMaquina",new ModeloMaquinaModel());
        }

        [HttpPost]
        public ActionResult AdicionarModeloMaquina(ModeloMaquinaModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.SSD == null && model.HD == null)
                {
                    ModelState.AddModelError(String.Empty, "É necessário preencher o hd ou o ssd.");
                    return View("AdicionarModeloMaquina", model);
                }

                var modeloRepositorio = Factory.CriarModeloMaquinaRepositorio();
                var maquinaRepositorio = Factory.CriarMaquinaRepositorio();

                var modeloMaquina = new ModeloMaquina()
                {
                    Name = model.Modelo
                };
                var newModelo = modeloRepositorio.Adicionar(modeloMaquina);

                var maquina = new Maquina()
                {
                    HD = model.HD,
                    SSD = model.SSD,
                    MemoriaRamGB1 = model.MemoriaRamGB1,
                    MemoriaRamGB2 = model.MemoriaRamGB2,
                    MemoriaRamGB3 = model.MemoriaRamGB3,
                    MemoriaRamGB4 = model.MemoriaRamGB4,
                    ModeloMaquina = newModelo,
                    ModeloMaquina_Id = newModelo.Id,
                    Processador = model.Processador,
                    TipoMaquina = TipoMaquina.Padrao
                };

                maquinaRepositorio.Adicionar(maquina);

                return RedirectToAction("ListarMaquinas");
            }

            return View("AdicionarModeloMaquina",model);
        }

        [HttpGet]
        public ActionResult EditarModeloMaquina(int? id)
        {
            var modeloMaquinaRepositorio = Factory.CriarModeloMaquinaRepositorio();
            Maquina maquina = null;
            ModeloMaquina modeloEscolhido = new ModeloMaquina();
            List<ModeloMaquina> modelos = modeloMaquinaRepositorio.BuscarTodos();

            if (id.HasValue)
            {
                var maquinaRepositorio = Factory.CriarMaquinaRepositorio();
                maquina = maquinaRepositorio.BuscarPorIdModelo(id.Value);
                modeloEscolhido = modelos.FirstOrDefault(m => m.Id == id.Value);
            }

            var model = new EditaMaquinaModel()
            {
                Modelos = modelos,
                Maquina = maquina,
                ModeloEscolhido = modeloEscolhido
            };
            return View("EditarMaquina",model);
        }

        [HttpPost]
        public ActionResult EditarModeloMaquina(EditaMaquinaModel model)
        {
            var modeloMaquinaRepositorio = Factory.CriarModeloMaquinaRepositorio();
            if (ModelState.IsValid)
            {
                var maquinaRepositorio = Factory.CriarMaquinaRepositorio();

                var modeloAtual = modeloMaquinaRepositorio.Atualizar(model.ModeloEscolhido);
                model.Maquina.AdicionarModelo(modeloAtual);
                maquinaRepositorio.Atualizar(model.Maquina);

                return RedirectToAction("EditarModeloMaquina");
            }

            model.Modelos = modeloMaquinaRepositorio.BuscarTodos();
            return View("EditarMaquina", model);
        }

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
                return ErroTratado(maquina);
                //return Json(new { message = maquina.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
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
                    repositorio.Deletar(listaModelosMaquina[modelo].Id);
                    listaModelosMaquina.Remove(listaModelosMaquina[modelo]);
                }
            }

            return Json(listaModelosMaquina, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult PesquisaPorPatrimonio(int patrimonio)
        {
            var repositorio = Factory.CriarMaquinaPessoalRepositorio();
            var mesaRepositorio = Factory.CriarMesaRepositorio();

            var maquina = repositorio.BuscarPorPatrimonio2(patrimonio);
            if (maquina == null)
            {
                return Json(new { Message = "Este patrimonio não existe" }, JsonRequestBehavior.AllowGet);
            }
            if (mesaRepositorio.TemMaquinaComPatrimonio(maquina.Patrimonio))
            {
                return Json(new { Message = "Este patrimonio já esta em outra mesa" }, JsonRequestBehavior.AllowGet);
            }

            return Json(maquina, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult SalvaEdicaoMaquina(Maquina model)
        {
            try
            {
                if (model.ModeloMaquina.Name == null)
                    return ErroTratado(new Exception("Preencha os campos corretamente"));

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
                    return ErroTratado(new Exception("Preencha os campos corretamente"));

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
                service.Deletar(model.Id);


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