using InfraMap.Dominio.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infra.Ef.Mapeamento
{
    public class MapeamentoUsuario : MapeamentoEntidade<Usuario>
    {
        public MapeamentoUsuario()
        {
            HasMany(t => t.Permissoes).WithMany(t => t.Usuarios);
        }
    }
}
