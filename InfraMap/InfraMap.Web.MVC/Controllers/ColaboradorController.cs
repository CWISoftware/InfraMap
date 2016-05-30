﻿using InfraMap.Dominio.Mesa;
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
            catch (UsuarioEmOutraMesaException e)
            {
                return Json(new { success = true, trocar = true, mensagemException = e.Message, temRamal = e.Data["TemRamal"], temMaquina = e.Data["TemMaquina"] });
            }
            catch (Exception e)
            {
                return ErroTratado(e);
            }

            return Json(new { success = true, trocar = false });
        }

        [HttpPost]
        public JsonResult TrocarMesaColaborador(int id, string colaborador, bool comMaquina, bool comRamal)
        {
            try
            {
                //TODO: fazer a troca com maquina e com ramal, verificar entrada dos dados
                var service = Factory.CriarMesaService();
                service.TrocarColaborador(id, colaborador, comMaquina, comRamal);
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