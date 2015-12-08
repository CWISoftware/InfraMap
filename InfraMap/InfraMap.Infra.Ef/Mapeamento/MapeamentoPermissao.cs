using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Autenticacao;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoPermissao : MapeamentoEntidade<Permissao>
    {
        public MapeamentoPermissao()
        {
            Property(t => t.Texto).IsRequired().HasMaxLength(50);
        }
    }
}
