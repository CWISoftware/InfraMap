using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class MaquinaModel
    {
        public int IdModeloMaquina { get; set; }

        public string Processador { get; set; }

        public int UnidadesMemoriaRam { get; set; }

        public int PenteMemoriaRamGB { get; set; }

        public int Ssd { get; set; }

        public int Hd { get; set; }
    }
}