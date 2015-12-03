using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloMaquina
{
    public class Maquina : EntidadeBase
    {
        public String Nome { get; set; }

        public String Tipo { get; set; }
    }
}
