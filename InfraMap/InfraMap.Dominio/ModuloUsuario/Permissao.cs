using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloUsuario
{
    public class Permissao : EntidadeBase
    {
        public String Texto { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
