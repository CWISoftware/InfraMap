using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Sede.Andar;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoAndar : MapeamentoEntidade<Andar>
    {
        public MapeamentoAndar()
        {
            Property(t => t.Descricao).IsRequired().HasMaxLength(200);
        }
    }
}
