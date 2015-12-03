using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloSede
{
    public class Sede : EntidadeBase
    {
        [Required]
        public String Nome { get; set; }

        [Required]
        public String NomeCidade { get; set; }
    }
}
