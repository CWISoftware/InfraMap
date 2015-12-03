using InfraMap.Dominio.ModuloGerente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infra.Ef.Mapeamento
{
    public class MapeamentoGerente : MapeamentoEntidade<Gerente>
    {
        public MapeamentoGerente()
        {
            HasRequired(t => t.Usuario).WithMany().WillCascadeOnDelete(false);
        }
    }
}
