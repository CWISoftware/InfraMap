using InfraMap.Dominio.Mesa.Maquina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class EditaMaquinaModel
    {
        public List<ModeloMaquina> Modelos { get; set; }

        public ModeloMaquina ModeloEscolhido { get; set; }
        public Maquina Maquina { get; set; }
    }
}