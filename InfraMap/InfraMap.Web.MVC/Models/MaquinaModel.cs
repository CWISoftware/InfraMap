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

        public string PlacaMae { get; set; }

        public int UnidadesMemoriaRam { get; set; }

        public int PenteMemoriaRamGB { get; set; }

        public int Ssd { get; set; }

        public int Hd { get; set; }

        public string Fonte { get; set; }

        public string PlacaRede { get; set; }

        public string DriverOtico { get; set; }
    }
}