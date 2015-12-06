using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Mesa
{
    public class Mesa : EntidadeBase
    {
        public int? Colaborador_Id { get; set; }
        public Usuario.Usuario Colaborador { get; set; }

        public int? Maquina_Id { get; set; }
        public Maquina.Maquina Maquina { get; set; }

        public int? Ramal_Id { get; set; }
        public Ramal.Ramal Ramal { get; set; }
    }
}
