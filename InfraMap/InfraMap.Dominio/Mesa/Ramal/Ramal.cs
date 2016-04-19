using System;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Mesa.Ramal
{
    public class Ramal : EntidadeBase
    {
        public TipoRamal Tipo { get; set; }

        public string Numero { get; set; }
    }
}
