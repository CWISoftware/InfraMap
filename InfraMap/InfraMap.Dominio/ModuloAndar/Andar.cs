using InfraMap.Comum;
using InfraMap.Dominio.ModuloMesa;
using InfraMap.Dominio.ModuloSede;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloAndar
{
    public class Andar : EntidadeBase
    {
        public Sede Sede { get; set; }

        [Required]
        public String Descricao { get; set; }

        public ICollection<Mesa> Mesas { get; set; }
    }
}
