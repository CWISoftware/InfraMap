using System;
using System.Collections.Generic;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Sede
{
    public class Sede : EntidadeBase
    {
        public string Nome { get; set; }

        public string NomeCidade { get; set; }

        public ICollection<Andar.Andar> Andares { get; set; }
    }
}
