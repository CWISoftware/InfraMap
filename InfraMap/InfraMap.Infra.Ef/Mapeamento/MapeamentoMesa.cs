using InfraMap.Dominio.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoMesa : MapeamentoEntidade<Mesa>
    {
        public MapeamentoMesa()
        {
            HasRequired(t => t.Andar).WithRequiredDependent();
            HasOptional(t => t.Colaborador).WithOptionalDependent();
            HasOptional(t => t.Maquina).WithOptionalDependent();
            HasOptional(t => t.Ramal).WithOptionalDependent();
        }
    }
}
