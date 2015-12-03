using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoEntidade<T> : EntityTypeConfiguration<T> where T : EntidadeBase
    {
        public MapeamentoEntidade()
        {
            HasKey(t => t.Id);
        }
    }
}
