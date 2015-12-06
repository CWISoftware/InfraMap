using System;
using System.Collections.Generic;
using InfraMap.Comum;

namespace InfraMap.Dominio.Sede
{
    public class Sede : EntidadeBase
    {
        public String Nome { get; set; }

        public String NomeCidade { get; set; }

        public ICollection<Andar.Andar> Andares { get; set; }
    }
}
