using InfraMap.Comum;
using InfraMap.Dominio.ModuloAndar;
using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloRamal;
using InfraMap.Dominio.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public int? Colaborador_Id { get; set; }
        public Usuario Colaborador { get; set; }

        public int? Maquina_Id { get; set; }
        public Maquina Maquina { get; set; }

        public int? Ramal_Id { get; set; }
        public Ramal Ramal { get; set; }
    }
}
