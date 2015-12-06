using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloRamal;
using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class MapaController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sede, string andar)
        {
            return View(sede + andar, new MesaModel());
        }

        [HttpPost]
        public JsonResult MesaAdicionarColaborador()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            string nome = Request.Params["colaborador"];
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var usuarioRepositorio = FabricaDeModulos.CriarUsuarioRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(id);
            mesa.Colaborador = usuarioRepositorio.BuscarPorNome(nome);
            if (mesa.Colaborador == null)
            {
                return ThrowError(new Exception("Colaborador não encontrado!"));
            }

            mesaRepositorio.Atualizar(mesa);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult MesaAdicionarMaquina()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            string maquina = Request.Params["maquina"];
            string tipo = Request.Params["tipo"];
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var maquinaRepositorio = FabricaDeModulos.CriarMaquinaRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(id);
            var novaMaquina = new Maquina()
            {
                Nome = maquina,
                Tipo = tipo
            };

            try
            {
                maquinaRepositorio.Adicionar(novaMaquina);
                mesa.Maquina = novaMaquina;
                mesaRepositorio.Atualizar(mesa);
            }
            catch (Exception e)
            {
                return ThrowError(e);
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult MesaAdicionarRamal()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            string numero = Request.Params["ramal"];
            string tipo = Request.Params["tipo"];
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var ramalRepositorio = FabricaDeModulos.CriarRamalRepositorio();

            var ramal = new Ramal()
            {
                Numero = numero,
                Tipo = tipo
            };

            var mesa = mesaRepositorio.BuscarPorId(id);

            try
            {
                ramalRepositorio.Adicionar(ramal);             
                mesa.Ramal = ramal;
                mesaRepositorio.Atualizar(mesa);
            }
            catch(Exception e)
            {
                return ThrowError(e);
            }
            
            return Json(new { success = true });
        }

        private JsonResult ThrowError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Json(new { Message = e.Message });
        }
    }
}