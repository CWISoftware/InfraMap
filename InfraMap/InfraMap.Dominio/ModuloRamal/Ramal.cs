using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloRamal
{
    public class Ramal : EntidadeBase
    {
        [Required]
        public String Tipo { get; set; }

        [Required]
        public String Numero { get; set; }
    }
}
