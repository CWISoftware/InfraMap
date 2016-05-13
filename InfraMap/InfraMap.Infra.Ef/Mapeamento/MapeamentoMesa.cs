using InfraMap.Dominio.Mesa;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoMesa : EntityTypeConfiguration<Mesa>
    {   
        public MapeamentoMesa()
        {
            HasOptional(t => t.Colaborador).WithMany().HasForeignKey(k => k.Colaborador_Id);
            HasOptional(t => t.MaquinaPessoal).WithMany().HasForeignKey(k => k.MaquinaPessoal_Id);
            HasOptional(t => t.Ramal).WithMany().HasForeignKey(k => k.Ramal_Id);
            Property(t => t.PontoEletrico).IsRequired().HasMaxLength(50);
            Property(t => t.PontoLogico1).IsRequired().HasMaxLength(50);
            Property(t => t.PontoLogico2).IsOptional().HasMaxLength(50);
        }
    }
}
