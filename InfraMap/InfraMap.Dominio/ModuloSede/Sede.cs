using InfraMap.Comum;
using InfraMap.Dominio.ModuloAndar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloSede
{
    public class Sede : EntidadeBase
    {
        public String Nome { get; set; }

        public String NomeCidade { get; set; }

        public ICollection<Andar> Andares { get; set; }
    }
}
