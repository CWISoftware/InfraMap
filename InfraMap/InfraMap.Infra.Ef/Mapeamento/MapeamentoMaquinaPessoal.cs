using InfraMap.Dominio.Mesa.Maquina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoMaquinaPessoal : MapeamentoEntidade<MaquinaPessoal>
    {
        public MapeamentoMaquinaPessoal()
        {
            Property(m => m.EtiquetaServico).IsRequired();
            Property(m => m.Patrimonio).IsRequired();

            HasRequired(m => m.Maquina).WithOptional();
        }
    }
}
