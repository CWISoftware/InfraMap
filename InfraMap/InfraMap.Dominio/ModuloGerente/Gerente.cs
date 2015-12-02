using InfraMap.Comum;
using InfraMap.Dominio.ModuloColaborador;
using InfraMap.Dominio.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloGerente
{
    public class Gerente : EntidadeBase
    {
        public Usuario Usuario { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
