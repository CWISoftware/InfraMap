using InfraMap.Comum;
using InfraMap.Dominio.ModuloGerente;
using InfraMap.Dominio.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloColaborador
{
    public class Colaborador : EntidadeBase
    {
        public Usuario Usuario { get; set; }

        public Gerente Gerente { get; set; }
    }
}
