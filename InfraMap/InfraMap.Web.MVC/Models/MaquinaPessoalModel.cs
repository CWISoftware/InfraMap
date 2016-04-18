using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class MaquinaPessoalModel
    {
        public int Patrimonio { get; set; }

        public string EtiquetaServico { get; set; }

        public int IdMesa { get; set; }

        public MaquinaModel Maquina { get; set; }
    }
}