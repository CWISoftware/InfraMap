using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Maquina;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoMaquina : MapeamentoEntidade<Maquina>
    {
        public MapeamentoMaquina()
        {
            Property(m => m.TipoMaquina).IsRequired();
            Property(m => m.SSD).IsOptional();
            Property(m => m.Processador).IsRequired().HasMaxLength(100);
            Property(m => m.MemoriaRamGB1).IsRequired();
            Property(m => m.MemoriaRamGB2).IsOptional();
            Property(m => m.MemoriaRamGB3).IsOptional();
            Property(m => m.MemoriaRamGB4).IsOptional();
            Property(m => m.HD).IsOptional();

            HasRequired(m => m.ModeloMaquina).WithMany().HasForeignKey(m => m.ModeloMaquina_Id);
        }
    }
}
