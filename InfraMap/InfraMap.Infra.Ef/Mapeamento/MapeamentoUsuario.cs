using InfraMap.Dominio.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoUsuario : MapeamentoEntidade<Usuario>
    {
        public MapeamentoUsuario()
        {
            HasMany(t => t.Permissoes).WithMany(t => t.Usuarios);

            HasRequired(t => t.ColaboradoresVinculados).WithMany().Map(t => t.MapKey("Gerente_Id"));
        }
    }
}
