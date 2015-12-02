using InfraMap.Comum;
using InfraMap.Dominio.ModuloSede;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloAndar
{
    public class Andar : EntidadeBase
    {
        public Sede Sede { get; set; }

        public String Descricao { get; set; }
    }
}
