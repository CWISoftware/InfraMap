using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloRamal;
using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    [Autorizador]
    public class MapaController : Controller
    {
        public void AdicionarColaborador(int idMesa, string colaborador)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var usuarioRepositorio = FabricaDeModulos.CriarUsuarioRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            mesa.Colaborador = usuarioRepositorio.BuscarPorNome(colaborador);
            if (mesa.Colaborador == null)
            {
                throw new Exception("Colaborador não encontrado!");
            }

            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarMaquina(int idMesa, string maquina)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var maquinaRepositorio = FabricaDeModulos.CriarMaquinaRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            mesa.Maquina = maquinaRepositorio.BuscarPorNome(maquina);
            if (mesa.Maquina == null)
            {
                throw new Exception("Maquina não encontrada!");
            }

            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarRamal(int idMesa, int idRamal)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var ramalRepositorio = FabricaDeModulos.CriarRamalRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            mesa.Ramal = ramalRepositorio.BuscarPorId(idRamal);
            if (mesa.Ramal == null)
            {
                throw new Exception("Ramal não encontrado!");
            }

            mesaRepositorio.Atualizar(mesa);
        }

        private IList<Maquina> BuscarMaquinaPeloFiltro(String term)
        {
            IMaquinaRepositorio maquina = FabricaDeModulos.CriarMaquinaRepositorio();
            if (String.IsNullOrEmpty(term))
            {
                return maquina.Buscar();
            }
            else
            {
                return maquina.BuscarListaPorNome(term);
            }
        }

        public JsonResult MaquinaAutoComplete(string term)
        {
            IList<Maquina> maquinaEncontrada = BuscarMaquinaPeloFiltro(term);
            var json = maquinaEncontrada.Select(maquinas => new { label = maquinas.Nome });
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private IList<Ramal> BuscarRamalPeloFiltro(String term)
        {
            IRamalRepositorio ramal = FabricaDeModulos.CriarRamalRepositorio();
            if (String.IsNullOrEmpty(term))
            {
                return ramal.Buscar();
            }
            else
            {
                return ramal.BuscarRamaisPorNumeros(term);
            }
        }

        public JsonResult RamalAutoComplete(string term)
        {
            IList<Ramal> ramalEncontrado = BuscarRamalPeloFiltro(term);
            var json = ramalEncontrado.Select(ramais => new { label = ramais.Numero });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}