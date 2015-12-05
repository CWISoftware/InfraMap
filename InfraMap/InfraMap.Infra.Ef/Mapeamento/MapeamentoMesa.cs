using InfraMap.Dominio.ModuloMesa;
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
            HasOptional(t => t.Colaborador).WithMany();
            HasOptional(t => t.Maquina).WithMany();
            HasOptional(t => t.Ramal).WithMany();
        }
    }
}
