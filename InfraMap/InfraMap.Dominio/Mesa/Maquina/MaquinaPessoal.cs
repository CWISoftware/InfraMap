using InfraMap.Dominio.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public class MaquinaPessoal : EntidadeBase
    {
        public int Patrimonio { get; set; }

        public string EtiquetaServico { get; set; }

        public Maquina Maquina { get; set; }
    }
}
