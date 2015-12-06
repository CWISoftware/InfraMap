using System;
using System.Collections.Generic;
using InfraMap.Comum;

namespace InfraMap.Dominio.Sede.Andar
{
    public class Andar : EntidadeBase
    {      
        public String Descricao { get; set; }

        public ICollection<Mesa.Mesa> Mesas { get; set; }
    }
}
