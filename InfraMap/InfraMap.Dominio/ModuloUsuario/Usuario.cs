using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloUsuario
{
    public class Usuario : EntidadeBase
    {
        public String Nome { get; set; }

        public String Login { get; set; }

        public String Senha { get; set; }
    }
}
