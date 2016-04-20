using System.Collections.Generic;
using InfraMap.Dominio.Comum;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfraMap.Dominio.Sede.Andar
{
    public class Andar : EntidadeBase
    {
        public string Descricao { get; set; }

        public ICollection<Mesa.Mesa> Mesas { get; set; }

        [NotMapped]
        public int MesaSelecionada { get; set; }
    }
}
