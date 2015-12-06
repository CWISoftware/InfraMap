using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfraMap.Web.MVC.Models;
using InfraMap.Dominio.Mesa;

namespace InfraMap.Web.MVC.Helpers
{
    public class MesaModelHelper
    {
        public static MesaModel EntidadeParaModel(Mesa mesa)
        {
            var model = new MesaModel()
            {
                Colaborador = mesa.Colaborador != null ? mesa.Colaborador.Nome.Truncate(21) : null,
                Maquina = mesa.Maquina != null ? mesa.Maquina.Nome + " - " + mesa.Maquina.Tipo : null,
                Ramal = mesa.Ramal != null ? mesa.Ramal.Numero + " - " + mesa.Ramal.Tipo : null,
                IdMaquina = mesa.Maquina != null ? mesa.Maquina.Id : 0,
                IdRamal = mesa.Ramal != null ? mesa.Ramal.Id : 0,
                IdColaborador = mesa.Colaborador != null ? mesa.Colaborador.Id : 0,
                Id = mesa.Id
            };

            return model;
        }
               
    }
}