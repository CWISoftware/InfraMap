using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Sede;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoSede : MapeamentoEntidade<Sede>
    {
        public MapeamentoSede()
        {
            HasMany(t => t.Andares).WithRequired();
        }
    }
}
