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
            HasOptional(t => t.Maquina).WithMany().HasForeignKey(k => k.Maquina_Id);
            HasOptional(t => t.Ramal).WithMany().HasForeignKey(k => k.Ramal_Id);
            Property(t => t.PontoEletrico).IsRequired().HasMaxLength(50);
            Property(t => t.PontoRede).IsRequired().HasMaxLength(50);
            Property(t => t.PontoTelefone).IsOptional().HasMaxLength(50);
        }
    }
}
