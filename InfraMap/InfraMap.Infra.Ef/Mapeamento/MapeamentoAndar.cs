using InfraMap.Dominio.ModuloAndar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoAndar : MapeamentoEntidade<Andar>
    {
        public MapeamentoAndar()
        {
            HasMany(t => t.Mesas).WithRequired();
        }
    }
}
