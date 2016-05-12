﻿using System;
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
            Property(m => m.UnidadesMemoriaRam).IsRequired();
            Property(m => m.TipoMaquina).IsRequired();
            Property(m => m.SSD).IsOptional();
            Property(m => m.Processador).IsRequired().HasMaxLength(100);
            Property(m => m.PenteMemoriaRamGB).IsRequired();
            Property(m => m.HD).IsOptional();

            HasRequired(m => m.ModeloMaquina).WithMany().HasForeignKey(m => m.ModeloMaquina_Id);
        }
    }
}
